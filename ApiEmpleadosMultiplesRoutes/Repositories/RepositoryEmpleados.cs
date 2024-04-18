using ApiEmpleadosMultiplesRoutes.Data;
using Microsoft.EntityFrameworkCore;
using NugetApiModels.Models;

namespace ApiEmpleadosMultiplesRoutes.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadoContext context;

        public RepositoryEmpleados(EmpleadoContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindEmpleadoAsync(int idEmpleado)
        {
            return await this.context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == idEmpleado);
        }

        public async Task<List<Empleado>>
           GetEmpleadosOficioAsync(string oficio)
        {
            return await this.context.Empleados
                .Where(z => z.Oficio == oficio).ToListAsync();
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<List<Empleado>>
            GetEmpleadosSalarioAsync(int salario, int iddepartamento)
        {
            return await this.context.Empleados
                .Where(x => x.IdDepartamento == iddepartamento
                && x.Salario >= salario).ToListAsync();
        }


    }
}
