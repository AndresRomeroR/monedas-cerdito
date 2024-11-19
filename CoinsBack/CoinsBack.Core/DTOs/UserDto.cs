namespace CoinsBack.Core.DTOs;

public class UserDto
{
    public double Id {  get; set; } 
    public string NombreCliente {  get; set; } 
    public string TelefonoCliente { get; set; }
    public string DireccionCliente { get; set; }
}
public class CreateUserDTO
{
    public double Id { get; set; }
    public string NombreUsuario { get; set; }
    public string TelefonoUsuario { get; set; }
    public string DireccionDetalle { get; set; }
    public int PaisId { get; set; }
    public string DepartamentoId {  get; set; }
    public int MunicipioId { get; set; }
}