using Microsoft.EntityFrameworkCore;
using NetCoreMovies.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovies.Data.Repository.Context
{
    // https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell

    // Criação da migração inicial, com diretório especificado:
    // PM> add-migration -name InitialConfiguration -outputdir "./Repository/Migrations"

    // Criação de script a ser executado no banco de dados entre duas migrações:
    // PM> script-migration -from InitMigration -to TargetMigration

    // Criação de script a ser executado no banco de dados desde a migração inicial:
    // PM> script-migration

    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
