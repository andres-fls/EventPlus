using System;
using System.Collections.Generic;
using MongoDB.Driver;
using eventPlus.Data;
using eventPlus.Models;

namespace eventPlus.Services
{
    public class EventoService
    {
        private readonly IMongoCollection<Evento> eventos;

        public EventoService()
        {
            MongoContext context = new MongoContext();
            eventos = context.Eventos;
        }

        // =========================================
        // CREAR EVENTO
        // =========================================
        public void CrearEvento(Evento evento)
        {
            if (evento == null)
                throw new Exception("Evento inválido.");

            if (string.IsNullOrWhiteSpace(evento.NombreEvento))
                throw new Exception("El nombre del evento es obligatorio.");

            if (string.IsNullOrWhiteSpace(evento.IdLider))
                throw new Exception("El líder es obligatorio.");

            if (evento.Fecha <= DateTime.Now)
                throw new Exception("La fecha debe ser futura.");

            if (evento.Hora <= DateTime.Now)
                throw new Exception("La hora debe ser futura.");

            // 🔴 VALIDAR CRUCE DEL LÍDER
            bool liderOcupado = eventos.Find(e =>
                e.IdLider == evento.IdLider &&
                e.Activo &&
                e.Fecha == evento.Fecha &&
                e.Hora == evento.Hora
            ).Any();

            if (liderOcupado)
                throw new Exception("Ya tienes un evento en esa fecha y hora.");

            // 🔴 VALIDAR INVITADOS
            if (evento.InvitadosIds != null && evento.InvitadosIds.Count > 0)
            {
                foreach (var invitadoId in evento.InvitadosIds)
                {
                    bool invitadoOcupado = eventos.Find(e =>
                        e.Activo &&
                        e.Fecha == evento.Fecha &&
                        e.Hora == evento.Hora &&
                        e.InvitadosIds != null &&
                        e.InvitadosIds.Contains(invitadoId)
                    ).Any();

                    if (invitadoOcupado)
                        throw new Exception("Uno de los invitados ya tiene un evento en ese horario.");
                }
            }

            evento.Activo = true;

            eventos.InsertOne(evento);
        }

        // =========================================
        // EDITAR EVENTO
        // =========================================
        public void EditarEvento(Evento evento)
        {
            if (evento == null || string.IsNullOrWhiteSpace(evento.Id))
                throw new Exception("Evento inválido.");

            var existente = eventos.Find(e => e.Id == evento.Id).FirstOrDefault();

            if (existente == null)
                throw new Exception("El evento no existe.");

            // 🔴 VALIDAR CRUCE DEL LÍDER
            bool liderOcupado = eventos.Find(e =>
                e.Id != evento.Id &&
                e.IdLider == evento.IdLider &&
                e.Activo &&
                e.Fecha == evento.Fecha &&
                e.Hora == evento.Hora
            ).Any();

            if (liderOcupado)
                throw new Exception("Ya tienes otro evento en ese horario.");

            // 🔴 VALIDAR INVITADOS
            if (evento.InvitadosIds != null && evento.InvitadosIds.Count > 0)
            {
                foreach (var invitadoId in evento.InvitadosIds)
                {
                    bool invitadoOcupado = eventos.Find(e =>
                        e.Id != evento.Id &&
                        e.Activo &&
                        e.Fecha == evento.Fecha &&
                        e.Hora == evento.Hora &&
                        e.InvitadosIds != null &&
                        e.InvitadosIds.Contains(invitadoId)
                    ).Any();

                    if (invitadoOcupado)
                        throw new Exception("Uno de los invitados ya tiene un evento en ese horario.");
                }
            }

            eventos.ReplaceOne(e => e.Id == evento.Id, evento);
        }

        // =========================================
        // EVENTOS POR USUARIO
        // =========================================
        public List<Evento> ObtenerEventosPorUsuario(string usuarioId)
        {
            if (string.IsNullOrWhiteSpace(usuarioId))
                return new List<Evento>();

            return eventos.Find(e =>
                e.Activo &&
                (e.IdLider == usuarioId ||
                 (e.InvitadosIds != null && e.InvitadosIds.Contains(usuarioId)))
            ).ToList();
        }

        // =========================================
        // FILTRAR POR MES
        // =========================================
        public List<Evento> ObtenerEventosPorMes(string usuarioId, int mes)
        {
            if (string.IsNullOrWhiteSpace(usuarioId))
                return new List<Evento>();

            return eventos.Find(e =>
            e.Activo &&
            e.Fecha.Month == mes &&
            (e.IdLider == usuarioId ||
            (e.InvitadosIds != null &&
            e.InvitadosIds.Contains(usuarioId)))
            ).ToList();
        }

        // Luego siguen ObtenerTodos, ObtenerEventosInvitado, etc.

        public List<Evento> ObtenerTodos()
        {
            return ObtenerTodos(true);
        }
        
        public List<Evento> ObtenerTodos(bool soloActivos = true)
        {
            var filtro = soloActivos ? Builders<Evento>.Filter.Eq(e => e.Activo, true) : Builders<Evento>.Filter.Empty;
            return eventos.Find(filtro).ToList();
        }
      

        public List<Evento> ObtenerEventosInvitado(string idUsuario)
        {
            return eventos.Find(e =>
                e.Activo &&
                e.InvitadosIds != null &&
                e.InvitadosIds.Contains(idUsuario)
            ).ToList();
        }

        public void DeshabilitarEvento(string idEvento)
        {
            var update = Builders<Evento>.Update.Set(e => e.Activo, false);
            eventos.UpdateOne(e => e.Id == idEvento, update);
        }

        public void HabilitarEvento(string idEvento)
        {
            var update = Builders<Evento>.Update.Set(e => e.Activo, true);
            eventos.UpdateOne(e => e.Id == idEvento, update);
        }

        public bool InvitadoTieneConflicto(string invitadoId, DateTime fecha, DateTime hora, string eventoIdActual = null)
        {
            var builder = Builders<Evento>.Filter;

            // Paso 1: Filtro que se puede traducir a MongoDB
            var filtroBase = builder.And(
                builder.Eq(e => e.Activo, true),
                builder.Eq(e => e.Fecha, fecha.Date),
                builder.AnyEq(e => e.InvitadosIds, invitadoId)
            );

            // Si estamos editando un evento existente, excluimos ese evento
            if (!string.IsNullOrEmpty(eventoIdActual))
            {
                filtroBase = builder.And(filtroBase, builder.Ne(e => e.Id, eventoIdActual));
            }

            // Obtenemos los eventos que cumplen la fecha y contienen al invitado
            var eventosCandidatos = eventos.Find(filtroBase).ToList();

            // Paso 2: En memoria, verificamos la hora exacta (ignorando segundos)
            foreach (var evento in eventosCandidatos)
            {
                if (evento.Hora.Hour == hora.Hour && evento.Hora.Minute == hora.Minute)
                {
                    return true; // Conflicto encontrado
                }
            }

            return false; // Sin conflicto
        }
    }
}