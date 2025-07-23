using Sistemas.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas.Abstractions;

public interface IUsuariosService
{
    Task<bool> Guardar(UsuariosDto usuario);
    Task<bool> Eliminar(int usuarioId);
    Task<UsuariosDto> Buscar(int id);
    Task<List<UsuariosDto>> Listar(Expression<Func<UsuariosDto, bool>> criterio);
    Task<bool> ExisteUsusario(int id, string nombre);
}