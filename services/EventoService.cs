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

        public List<Evento> ObtenerTodos()
        {
            return eventos.Find(e => e.Activo).ToList();
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
            if (string.IsNullOrWhiteSpace(idEvento))
                throw new Exception("ID inválido.");

            var update = Builders<Evento>.Update.Set(e => e.Activo, false);
            eventos.UpdateOne(e => e.Id == idEvento, update);
        }

    }
}