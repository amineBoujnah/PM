using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Data.Infrastructure;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
   public class TeamService: Service<Team>, ITeamService
    {

            static IDatabaseFactory Factory = new DatabaseFactory();
            static IUnitOfWork utk = new UnitOfWork(Factory);
            public TeamService() : base(utk) { }

            //Recherche


            public IEnumerable<Team> SearchProjectByName(string searchString)
            {
                IEnumerable<Team> ProjectDomain = GetMany();
                if (!String.IsNullOrEmpty(searchString))
                {
                    ProjectDomain = GetMany(x => x.name.Contains(searchString));
                }
                return ProjectDomain;
            }
        }
    }
