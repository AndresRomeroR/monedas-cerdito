namespace CoinsBack.Core.DTOs;

public class MunicipioDTO
{
    public int Id { get; set; }
    public string CodigoMunicipio { get; set; }
    public string NombreMunicipio { get; set; }
}

public class CreateMunicipioDTO
{
    public int Id { get; set; }
    public string CodigoMunicipio { get; set; }
    public string NombreMunicipio { get; set; }
    public string CodigoDepartamento { get; set; }
}
