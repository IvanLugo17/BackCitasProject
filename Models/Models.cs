using System.ComponentModel.DataAnnotations;

namespace DocsAgenda.Models
{

    public class Usuario
    {
        [Key] public int IdUser { get; set; }
        public string NomUser { get; set; }
        public string Psswrd { get; set; }
        public bool ItsFbUsr { get; set; }
        public string? FbUser { get; set; }
    }

    public class Doctores
    { 
    [Key] public int IdDoctor { get; set; }
    public string NomDoctor { get; set; }
    }

    public class Agenda
    {
        [Key] public int IdAgenda { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public int IdEstatus { get; set; }
        public string Paciente { get; set; }
        public string CorreoPaciente { get; set; }
    }

    #region Error
    public class Models
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    #endregion
}
