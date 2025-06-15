using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sistemas.Domain.DTO;

namespace Sistemas.Abstractions;

public interface ISistemasService
{
    Task<bool> Guardar(SistemasDto cliente);
    Task<bool> Eliminar(int sistemaId);
    Task<SistemasDto> Buscar(int id);
    Task<List<SistemasDto>> Listar(Expression<Func<SistemasDto, bool>> criterio);
    Task<bool> ExisteSistema(int id, string nombre);

}
