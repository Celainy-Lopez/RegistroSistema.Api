using Microsoft.EntityFrameworkCore;
using Sistemas.Abstractions;
using Sistemas.Data.Context;
using Sistemas.Data.Models;
using Sistemas.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas.Services;

public class UsuariosService(IDbContextFactory<SistemasContext> DbFactory) : IUsuariosService
{
    public async Task<UsuariosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var usuario = await contexto.Usuario
            .Where(e => e.UsuariaId == id).Select(p => new UsuariosDto()
            {
                UsuarioId = p.UsuariaId,
                Nombre = p.Nombre,
                Balance = p.Balance
            }).FirstOrDefaultAsync();
        return usuario ?? new UsuariosDto();
    }

    public async Task<bool> Eliminar(int usuarioId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Usuario
            .Where(e => e.UsuariaId == usuarioId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteUsusario(int id, string nombre)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Usuario
            .AnyAsync(e => e.UsuariaId != id
            && e.Nombre.ToLower().Equals(nombre.ToLower()));
    }

    private async Task<bool> Insertar(UsuariosDto usuarioDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var usuario = new Usuarios()
        {
            Nombre = usuarioDto.Nombre,
            Balance = usuarioDto.Balance
        };
        contexto.Usuario.Add(usuario);
        var guardo = await contexto.SaveChangesAsync() > 0;
        usuarioDto.UsuarioId = usuario.UsuariaId;
        return guardo;
    }

    private async Task<bool> Modificar(UsuariosDto usuarioDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var usuario = new Usuarios()
        {
            UsuariaId = usuarioDto.UsuarioId,
            Nombre = usuarioDto.Nombre,
            Balance = usuarioDto.Balance
        };
        contexto.Update(usuario);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Usuario
            .AnyAsync(e => e.UsuariaId == id);
    }


    public async Task<bool> Guardar(UsuariosDto usuario)
    {
        if (!await Existe(usuario.UsuarioId))
            return await Insertar(usuario);
        else
            return await Modificar(usuario);
    }

    public async Task<List<UsuariosDto>> Listar(Expression<Func<UsuariosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Usuario.Select(p => new UsuariosDto()
        {
            UsuarioId = p.UsuariaId,
            Nombre = p.Nombre,
            Balance = p.Balance,
        })
        .Where(criterio)
        .ToListAsync();
    }
}