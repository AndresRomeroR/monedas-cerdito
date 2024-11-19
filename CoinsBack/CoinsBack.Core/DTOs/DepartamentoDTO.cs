namespace CoinsBack.Core.DTOs;

public class DepartamentoDTO
{
    public int Id { get; set; }
    public string CodigoDepartamento { get; set; }
    public string NombreDepartamento { get; set; }
}

public class CreateDepartamentoDTO
{
    public int Id { get; set; }
    public string CodigoDepartamento { get; set; }
    public string NombreDepartamento { get; set; }
    public int CodigoPais { get; set; }
}
