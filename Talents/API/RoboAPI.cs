using Robo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Robo.Util;
using Microsoft.EntityFrameworkCore;

namespace Robo.API
{
    public class RoboAPI
    {
        private static List<PartCategory> CotoveloOptions = new List<PartCategory>() {
            new PartCategory() { Id = 1, Name = "Em Repouso" },
            new PartCategory() { Id =2, Name = "Levemente Contraído" },
            new PartCategory() { Id =3, Name = "Contraído" },
            new PartCategory() { Id =4, Name = "Fortemente Contraído" }
        };

        private static List<PartCategory> PulsoOptions = new List<PartCategory>() {
            new PartCategory() { Id = 1, Name = "Rotação -90º" },
            new PartCategory() { Id =2, Name = "Rotação -45º" },
            new PartCategory() { Id =3, Name = "Em Repouso" },
            new PartCategory() { Id =4, Name = "Rotação 45º" },
            new PartCategory() { Id =5, Name = "Rotação 90º" },
            new PartCategory() { Id =6, Name = "Rotação 1350º" },
            new PartCategory() { Id =7, Name = "Rotação 180º" }
        };

        private static List<PartCategory> JoelhoOptions = new List<PartCategory>() {
            new PartCategory() { Id = 1, Name = "Estendido " },
            new PartCategory() { Id =2, Name = "Em Repouso" },
            new PartCategory() { Id =3, Name = "Levemente Contraído" },
            new PartCategory() { Id =4, Name = "Contraído" },
            new PartCategory() { Id =5, Name = "Fortemente Contraído" },
            new PartCategory() { Id =6, Name = "Flexionado" }
        };

        private static List<PartCategory> QuadrilOptions = new List<PartCategory>() {
            new PartCategory() { Id = 1, Name = "Rotação -90º" },
            new PartCategory() { Id =2, Name = "Rotação -45º" },
            new PartCategory() { Id =3, Name = "Em Repouso" },
            new PartCategory() { Id =4, Name = "Rotação 45º" },
            new PartCategory() { Id =5, Name = "Rotação 90º" },
        };

        private static List<PartCategory> HeadRotationOptions = new List<PartCategory>() {
            new PartCategory() { Id = 1, Name = "Rotação -90º" },
            new PartCategory() { Id =2, Name = "Rotação -45º" },
            new PartCategory() { Id =3, Name = "Em Repouso" },
            new PartCategory() { Id =4, Name = "Rotação 45º" },
            new PartCategory() { Id =5, Name = "Rotação 90º" },
        };

        private static List<PartCategory> HeadInclinationOptions = new List<PartCategory>() {
            new PartCategory() { Id = 1, Name = "Para Cima" },
            new PartCategory() { Id =2, Name = "Em Repouso" },
            new PartCategory() { Id =3, Name = "Para Baixo" }
        };

        public static Robo.Models.Robo GetRobo()
        {
            try
            {
                Robo.Models.Robo _robo = new Robo.Models.Robo();

                using (RoboContext db = new RoboContext())
                {
                    _robo = db.Robo.FirstOrDefault();

                    if (_robo == null)
                    {
                        _robo = new Models.Robo() { CotoveloDireito = 1, CotoveloEsquerdo = 1, PulsoDireito = 3, PulsoEsquerdo = 3, JoelhoDireito = 2, JoelhoEsquerdo = 2, Quadril = 3, HeadInclination = 2, HeadRotation = 3 };

                        db.Robo.Add(_robo);
                        db.SaveChanges();
                    }

                    _robo.CotoveloDireitoOptions = CotoveloOptions;
                    _robo.CotoveloEsquerdoOptions = CotoveloOptions;

                    _robo.PulsoDireitoOptions = PulsoOptions;
                    _robo.PulsoEsquerdoOptions = PulsoOptions;

                    _robo.JoelhoEsquerdoOptions = JoelhoOptions;
                    _robo.JoelhoDireitoOptions = JoelhoOptions;

                    _robo.QuadrilOptions = QuadrilOptions;

                    _robo.HeadInclinationOptions = HeadInclinationOptions;
                    _robo.HeadRotationOptions = HeadRotationOptions;

                    return _robo;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void UpdateRobo(Robo.Models.Robo _model)
        {
            try
            {
                using (RoboContext db = new RoboContext())
                {
                    db.Entry(_model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
