using MongoDB.Driver;
using eventPlus.Data;
using System.Collections.Generic;
using System;
using eventPlus.Models;
using System.Windows.Forms;

namespace eventPlus.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> usuarios;

        public UsuarioService()
        {
            MongoContext context = new MongoContext();
            usuarios = context.Usuarios;
        }

        // ==========================
        // REGISTRAR USUARIO
        // ==========================
        public void Registrar(Usuario usuario)
        {
            if (usuario == null)
                throw new Exception("Usuario inválido.");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("Nombre requerido.");

            if (string.IsNullOrWhiteSpace(usuario.Correo))
                throw new Exception("Correo requerido.");

            if (string.IsNullOrWhiteSpace(usuario.Password))
                throw new Exception("Password requerido.");

            if (string.IsNullOrWhiteSpace(usuario.Rol))
                throw new Exception("Rol requerido.");

            // 🔴 VALIDAR CORREO DUPLICADO
            bool existe = usuarios
                .Find(u => u.Correo == usuario.Correo)
                .Any();

            if (existe)
                throw new Exception("El correo ya está registrado.");

            // 🔴 VALIDACIONES PARA INVITADOS
            if (usuario.Rol == "Invitado")
            {
                if (string.IsNullOrWhiteSpace(usuario.Cedula))
                    throw new Exception("Cédula requerida para invitados.");

                if (string.IsNullOrWhiteSpace(usuario.Telefono))
                    throw new Exception("Teléfono requerido para invitados.");

                if (string.IsNullOrWhiteSpace(usuario.Genero))
                    throw new Exception("Género requerido.");

                if (usuario.Edad == null || usuario.Edad <= 0)
                    throw new Exception("Edad inválida.");
            }

            usuarios.InsertOne(usuario);
        }

        // ==========================
        // LOGIN
        // ==========================
        public Usuario Login(string correo, string password)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Correo y contraseña son obligatorios.");

            correo = correo.Trim();
            password = password.Trim();

            Usuario usuario = usuarios
                .Find(u => u.Correo == correo && u.Password == password)
                .FirstOrDefault();

            if (usuario == null)
                throw new Exception("Credenciales incorrectas.");

            return usuario;
        }

        // ==========================
        // LISTAR TODOS
        // ==========================
        public List<Usuario> ObtenerTodos()
        {
            return usuarios.Find(_ => true).ToList();
        }

        // ==========================
        // OBTENER SOLO INVITADOS
        // ==========================
        public List<Usuario> ObtenerInvitados()
        {
            return usuarios
                .Find(u => u.Rol == "Invitado")
                .ToList();
        }

        public List<Usuario> ObtenerPorIds(List<string> ids)
        {
            return new List<Usuario>();
        }
    }
}