using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsBack.Core.DTOs;

public class PaisDTO
{
    public int Id { get; set; }
    public string CodigoPais { get; set; }
    public string NombrePais { get; set; }
}
public class CreatePaisDTO
{
    public string CodigoPais { get; set; }
    public string NombrePais { get; set; }
}
