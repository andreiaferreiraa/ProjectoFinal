namespace HockeyPT.Migrations
{
    using HockeyPT.Models;
    using IdentitySample.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //*****************************************************************************************************************
            // adiciona Equipas
            var equipas = new List<Equipas> {
               new Equipas {ID=1, Nome="Benfica" ,Logotipo="Benfica.jpg", Cidade="Lisboa" },
               new Equipas {ID=2, Nome="Sporting" ,Logotipo="Sporting.jpg",  Cidade="Lisboa" },
               new Equipas {ID=3, Nome="FC Porto",Logotipo="Porto.jpg",  Cidade="Porto" },
               new Equipas {ID=4, Nome="UD Oliveirense",Logotipo="Oliveirense.jpg",  Cidade="Oliveira do Hospital" },
               new Equipas {ID=5, Nome="Valongo" ,Logotipo="Valongo.jpg",  Cidade="Valongo" },
               new Equipas {ID=6, Nome="Junventude de Viana", Logotipo="Viana.jpg",  Cidade="Viana do Castelo" },
               new Equipas {ID=7, Nome="Sp. Tomar" ,Logotipo="Tomar.jpg",  Cidade="Tomar" },
               new Equipas {ID=8, Nome="OC Barcelos" ,Logotipo="Barcelos.jpg",  Cidade="Barcelos" },
               new Equipas {ID=9, Nome="Turquel" ,Logotipo="Turquel.jpg",  Cidade="Turquel" },
               new Equipas {ID=10, Nome="Pa�o de Arcos",Logotipo="PacoArcos.jpg",  Cidade="Pa�o de Arcos" },
               new Equipas {ID=11, Nome="Valen�a" ,Logotipo="Valenca.jpg", Cidade="Valen�a" },
               new Equipas {ID=12, Nome="HC Braga" ,Logotipo="Braga.jpg",  Cidade="Braga" },
               new Equipas {ID=13, Nome="Infante Sagres",Logotipo="InfanteSagres.jpg",  Cidade="Porto" },
               new Equipas {ID=14, Nome="Gr�ndola" , Logotipo="Grandola.jpg",  Cidade="Gr�ndola" }
            };
            equipas.ForEach(ee => context.Equipas.AddOrUpdate(e => e.ID, ee));
            context.SaveChanges();

            //*********************************************************************************************************************
            // adiciona Jogadores
            var jogadores = new List<Jogadores> {
                //Benfica
               new Jogadores {ID=1, Nome="Pedro Henriques", Posicao="Guarda Redes", DataNascimento= new DateTime(1990,09,27), Nacionalidade="Portugal", Altura=1.86 , Peso=82.0, Fotografia="PedroHenriques.jpg", EquipaPK=1 },
               new Jogadores {ID=2, Nome="Guillem Trabal", Posicao="Guarda Redes", DataNascimento=new DateTime(1979,06,11), Nacionalidade="Espanha", Altura=1.85, Peso=80.3, Fotografia="GuillemTrabal.jpg", EquipaPK=1  },
               new Jogadores {ID=3, Nome="Valter Neves", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1983,08,12), Nacionalidade="Portugal", Altura=1.69, Peso=73.5, Fotografia="ValterNeves.jpg", EquipaPK=1  },
               new Jogadores {ID=4, Nome="Diogo Rafael", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1989,11,17), Nacionalidade="Portugal", Altura=1.71, Peso=79.2, Fotografia="DiogoRafael.jpg", EquipaPK=1  },
               new Jogadores {ID=5, Nome="Miguel Vieira", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1996,09,05), Nacionalidade="Portugal",Altura=1.70, Peso=76.7, Fotografia="MiguelVieira.jpg", EquipaPK=1  },
               new Jogadores {ID=6, Nome="Tiago Rafael", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1983,09,09), Nacionalidade="Portugal", Altura=1.75, Peso=82.9, Fotografia="TiagoRafael.jpg", EquipaPK=1  },
               new Jogadores {ID=7, Nome="Jordi Adroher", Posicao="Avan�ado", DataNascimento=new DateTime(1984,11,22), Nacionalidade="Espanha", Altura=1.73, Peso=72.0, Fotografia="JordiAdroher.jpg", EquipaPK=1  },
               new Jogadores {ID=8, Nome="Miguel Rocha", Posicao="Avan�ado", DataNascimento=new DateTime(1993,01,05), Nacionalidade="Portugal", Altura=1.85, Peso=80.1, Fotografia="MiguelRocha.jpg", EquipaPK=1 },
               new Jogadores {ID=9, Nome="Carlos Nicol�a", Posicao="Avan�ado", DataNascimento=new DateTime(1986,04,04), Nacionalidade="Argentina", Altura=1.80, Peso=79.0, Fotografia="CarlosNicolia.jpg", EquipaPK=1 },
               new Jogadores {ID=10, Nome="Jo�o Rodrigues", Posicao="Avan�ado", DataNascimento=new DateTime(1990,07,15), Nacionalidade="Portugal", Altura=1.85, Peso=84.4, Fotografia="JoaoRodrigues.jpg", EquipaPK=1 },
               //Sporting
               new Jogadores {ID=11, Nome="�ngelo Gir�o", Posicao="Guarda Redes", DataNascimento=new DateTime(1989,08,28), Nacionalidade="Portugal", Altura=1.76, Peso=87.2, Fotografia="AngeloGirao.jpg", EquipaPK=2 },
               new Jogadores {ID=12, Nome="Z� Diogo Macedo", Posicao="Guarda Redes", DataNascimento=new DateTime(1993,07,17), Nacionalidade="Portugal", Altura=1.78, Peso=86.5, Fotografia="ZeDiogoMacedo.jpg", EquipaPK=2 },
               new Jogadores {ID=13, Nome="Ferran Font", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1996,11,12), Nacionalidade="Espanha", Altura=1.70, Peso=82.7, Fotografia="FerranFont.jpg", EquipaPK=2 },
               new Jogadores {ID=14, Nome="Mat�as Platero", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1988,01,17), Nacionalidade="Argentina", Altura=1.86, Peso=81.1, Fotografia="MatiasPlatero.jpg", EquipaPK=2 },
               new Jogadores {ID=15, Nome="Caio", Posicao="Defesa/M�dio", DataNascimento= new DateTime(1982,01,05), Nacionalidade="Portugal", Altura=1.79, Peso=78.0, Fotografia="Caio.jpg", EquipaPK=2  },
               new Jogadores {ID=16, Nome="Henrique Magalh�es", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1991,10,22), Nacionalidade="Portugal", Altura=1.85, Peso=79.0, Fotografia="HenriqueMagalhaes.jpg", EquipaPK=2  },
               new Jogadores {ID=17, Nome="Pedro Gil", Posicao="Avan�ado", DataNascimento=new DateTime(1980,04,26), Nacionalidade="Espanha", Altura=1.87, Peso=83.8, Fotografia="PedroGil.jpg", EquipaPK=2 },
               new Jogadores {ID=18, Nome="Jo�o Pinto", Posicao="Avan�ado", DataNascimento=new DateTime(1987,01,28), Nacionalidade="Angola", Altura=1.75, Peso=78.3, Fotografia="JoaoPinto.jpg", EquipaPK=2 },
               new Jogadores {ID=19, Nome="V�tor Hugo", Posicao="Avan�ado", DataNascimento=new DateTime(1984,10,23), Nacionalidade="Portugal", Altura=1.81, Peso=85.4, Fotografia="VitorHugo.jpg", EquipaPK=2 },
               new Jogadores {ID=20, Nome="Toni P�rez", Posicao="Avan�ado", DataNascimento=new DateTime(1990,06,07), Nacionalidade="Espanha", Altura=1.78, Peso=76.0, Fotografia="ToniPerez.jpg", EquipaPK=2 },
                //FC Porto
                new Jogadores {ID=21, Nome="Carles Grau", Posicao="Guarda Redes", DataNascimento=new DateTime(1990,03,10), Nacionalidade="Espanha", Altura=1.78, Peso=74.5, Fotografia="CarlesGrau.jpg", EquipaPK=3  },
               new Jogadores {ID=22, Nome="N�lson Filipe", Posicao="Guarda Redes", DataNascimento=new DateTime(1984,11,05), Nacionalidade="Portugal", Altura=1.75, Peso=78.2, Fotografia="NelsonFilipe.jpg", EquipaPK=3   },
               new Jogadores {ID=23, Nome="Jo�o Lima", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1990,03,10), Nacionalidade="Espanha", Altura=1.86, Peso=87.4, Fotografia="JoaoLima.jpg", EquipaPK=3   },
               new Jogadores {ID=24, Nome="Ton Baliu", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1989,01,13), Nacionalidade="Espanha", Altura=1.84, Peso=83.0, Fotografia="TonBaliu.jpg", EquipaPK=3   },
               new Jogadores {ID=25, Nome="H�lder Nunes", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1994,02,23), Nacionalidade="Portugal", Altura=1.78, Peso=89.3, Fotografia="HelderNunes.jpg", EquipaPK=3   },
               new Jogadores {ID=26, Nome="Telmo Pinto", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1993,01,23), Nacionalidade="Portugal", Altura=1.76, Peso=75.2, Fotografia="TelmoPinto.jpg", EquipaPK=3   },
               new Jogadores {ID=27, Nome="Rafa Costa", Posicao="Avan�ado", DataNascimento=new DateTime(1991,11,10), Nacionalidade="Portugal", Altura=1.83, Peso=87.2, Fotografia="RafaCosta.jpg", EquipaPK=3   },
               new Jogadores {ID=28, Nome="Alvarinho", Posicao="Avan�ado", DataNascimento=new DateTime(1996,04,18), Nacionalidade="Portugal", Altura=1.82, Peso=85.4, Fotografia="Alvarinho.jpg", EquipaPK=3   },
               new Jogadores {ID=29, Nome="Jorge Silva", Posicao="Avan�ado", DataNascimento=new DateTime(1984,05,09), Nacionalidade="Portugal", Altura=1.87, Peso=81.3, Fotografia="JorgeSilva.jpg", EquipaPK=3   },
               new Jogadores {ID=30, Nome="Gon�alo Alves", Posicao="Avan�ado", DataNascimento=new DateTime(1993,07,26), Nacionalidade="Portugal", Altura=1.78, Peso=80.0, Fotografia="GoncaloAlves.jpg", EquipaPK=3   },
               //UD Oliveirense
               new Jogadores {ID=31, Nome="Domingos Pinho", Posicao="Guarda Redes", DataNascimento=new DateTime(1980,07,15), Nacionalidade="Portugal",  Altura=1.77, Peso=69.1, Fotografia="DomingosPinho.jpg", EquipaPK=4  },
               new Jogadores {ID=32, Nome="Xavier Puigb�", Posicao="Guarda Redes", DataNascimento=new DateTime(1987,05,23), Nacionalidade="Espanha", Altura=1.83, Peso=76.3, Fotografia="XavierPuigbi.jpg", EquipaPK=4  },
               new Jogadores {ID=33, Nome="Nuno Ara�jo", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1988,06,05), Nacionalidade="Mo�ambique", Altura=1.84, Peso=77.2, Fotografia="NunoAraujo.jpg", EquipaPK=4  },
               new Jogadores {ID=34, Nome="Pedro Moreira", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1985,07,17), Nacionalidade="Portugal", Altura=1.78, Peso=70.0, Fotografia="PedroMoreira.jpg", EquipaPK=4  },
               new Jogadores {ID=35, Nome="Jordi Bargall�", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1979,12,05), Nacionalidade="Espanha", Altura=1.69, Peso=65.0, Fotografia="JordiBargallo.jpg", EquipaPK=4  },
               new Jogadores {ID=36, Nome="Jordi Burgaya", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1995,06,08), Nacionalidade="Espanha", Altura=1.82, Peso=81.4, Fotografia="JordiBurgaya.jpg", EquipaPK=4  },
               new Jogadores {ID=37, Nome="Jepi Selva", Posicao="Avan�ado", DataNascimento=new DateTime(1985,12,09), Nacionalidade="Espanha", Altura=1.76, Peso=70.3, Fotografia="JepiSelva.jpg", EquipaPK=4  },
               new Jogadores {ID=38, Nome="Pablo Cancela", Posicao="Avan�ado", DataNascimento=new DateTime(1988,03,08), Nacionalidade="Espanha", Altura=1.71, Peso=68.1, Fotografia="PabloCancela.jpg", EquipaPK=4  },
              new Jogadores {ID=39, Nome="Jo�o Souto", Posicao="Avan�ado", DataNascimento=new DateTime(1992,07,26), Nacionalidade="Portugal", Altura=1.78, Peso=75.7, Fotografia="JoaoSouto.jpg", EquipaPK=4  },
               new Jogadores {ID=40, Nome="Ricardo Barreiros", Posicao="Avan�ado", DataNascimento=new DateTime(1982,01,17), Nacionalidade="Portugal", Altura=1.81, Peso=79.0, Fotografia="RicardoBarreiros.jpg", EquipaPK=4  },
               //Valongo
               new Jogadores {ID=41, Nome="Rui Mendes", Posicao="Guarda Redes", DataNascimento=new DateTime(1999,03,12), Nacionalidade="Portugal", Altura=1.85, Peso=79.1, Fotografia="RuiMendes.jpg", EquipaPK=5  },
               new Jogadores {ID=42, Nome="Leonardo Pais", Posicao="Guarda Redes", DataNascimento=new DateTime(1990,08,24), Nacionalidade="Portugal", Altura=1.76, Peso=67.2, Fotografia="LeonardoPais.jpg", EquipaPK=5  },
               new Jogadores {ID=43, Nome="Diogo Abreu", Posicao="Defesa/M�dio", DataNascimento=new DateTime(2001,03,06), Nacionalidade="Portugal", Altura=1.81, Peso=76.7, Fotografia="DiogoAbreu.jpg", EquipaPK=5  },
               new Jogadores {ID=44, Nome="Xavier Cardoso", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1995,02,14), Nacionalidade="Portugal", Altura=1.74, Peso=69.7, Fotografia="XavierCardoso.jpg", EquipaPK=5  },
               new Jogadores {ID=45, Nome="Poka", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1989,05,07), Nacionalidade="Portugal", Altura=1.86, Peso=80.1, Fotografia="Poka.jpg", EquipaPK=5  },
               new Jogadores {ID=46, Nome="Pedro Mendes", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1993,01,04), Nacionalidade="Portugal", Altura=1.79, Peso=80.2, Fotografia="PedroMendes.jpg", EquipaPK=5  },
               new Jogadores {ID=47, Nome="Lu�s Melo", Posicao="Avan�ado", DataNascimento=new DateTime(1996,04,13), Nacionalidade="Portugal", Altura=1.78, Peso=81.2, Fotografia="LuisMelo.jpg", EquipaPK=5  },
               new Jogadores {ID=48, Nome="Gon�alo Neto", Posicao="Avan�ado", DataNascimento=new DateTime(1988,02,05), Nacionalidade="Portugal" , Altura=1.73, Peso=81.1, Fotografia="GoncaloNeto.jpg", EquipaPK=5  },
               new Jogadores {ID=49, Nome="Guilherme Silva", Posicao="Avan�ado", DataNascimento=new DateTime(1994,08,24), Nacionalidade="Portugal" , Altura=1.77, Peso=83.2, Fotografia="GuilhermeSilva.jpg", EquipaPK=5  },
               new Jogadores {ID=50, Nome="R�ben Pereira", Posicao="Avan�ado", DataNascimento=new DateTime(1990,05,09), Nacionalidade="Portugal" , Altura=1.79, Peso=84.1, Fotografia="RubenPereira.jpg", EquipaPK=5  },
               //Juventude de Viana
               new Jogadores {ID=51, Nome="Paulo Matos", Posicao="Guarda Redes", DataNascimento=new DateTime(1973,11,16), Nacionalidade="Portugal" , Altura=1.73, Peso=68.1, Fotografia="PauloMatos.jpg", EquipaPK=6  },
               new Jogadores {ID=52, Nome="Telmo Fernandes", Posicao="Guarda Redes", DataNascimento=new DateTime(1980,07,22), Nacionalidade="Portugal" , Altura=1.82, Peso=78.2, Fotografia="TelmoFernandes.jpg", EquipaPK=6  },
               new Jogadores {ID=53, Nome="Romeu Rocha", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1978,02,08), Nacionalidade="Portugal" ,  Altura=1.85, Peso=79.3, Fotografia="RomeuRocha.jpg", EquipaPK=6  },
               new Jogadores {ID=54, Nome="Francisco Silva", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1991,05,05), Nacionalidade="Portugal" , Altura=1.74, Peso=71.4, Fotografia="FranciscoSilva.jpg", EquipaPK=6  },
               new Jogadores {ID=55, Nome="N�lson Pereira", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1988,08,29), Nacionalidade="Portugal" , Altura=1.71, Peso=68.1, Fotografia="NelsonPereira.jpg", EquipaPK=6  },
               new Jogadores {ID=56, Nome="Nuno Santos", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1990,05,02), Nacionalidade="Portugal" , Altura=1.70, Peso=65.3, Fotografia="NunoSantos.jpg", EquipaPK=6  },
               new Jogadores {ID=57, Nome="Gustavo Lima", Posicao="Avan�ado", DataNascimento=new DateTime(1993,11,13), Nacionalidade="Portugal", Altura=1.72,Peso=69.6, Fotografia="GustavoLima.jpg", EquipaPK=6  },
               new Jogadores {ID=58, Nome="T� Silva", Posicao="Avan�ado", DataNascimento=new DateTime(1976,10,07), Nacionalidade="Portugal", Altura=1.83,Peso=74.5, Fotografia="ToSilva.jpg", EquipaPK=6  },
               new Jogadores {ID=59, Nome="Andr� Azevedo", Posicao="Avan�ado", DataNascimento=new DateTime(1976,03,27), Nacionalidade="Portugal", Altura=1.67, Peso=68.1, Fotografia="AndreAzevedo.jpg", EquipaPK=6  },
               new Jogadores {ID=60, Nome="Emanuel Garc�a", Posicao="Avan�ado", DataNascimento=new DateTime(1983,07,21), Nacionalidade="Argentina", Altura=1.71, Peso=75.0, Fotografia="EmanuelGarcia.jpg", EquipaPK=6  },
               //Sp. Tomar 
               new Jogadores {ID=61, Nome="Marco Gaspar", Posicao="Guarda Redes", DataNascimento=new DateTime(1988,03,18), Nacionalidade="Portugal", Altura=1.75, Peso=73.3, Fotografia="MarcoGaspar.jpg", EquipaPK=7  },
               new Jogadores {ID=62, Nome="Diogo Alves", Posicao="Guarda Redes", DataNascimento=new DateTime(1997,02,04), Nacionalidade="Portugal", Altura=1.78, Peso=79.1, Fotografia="DiogoAlves.jpg", EquipaPK=7  },
               new Jogadores {ID=63, Nome="Jo�o Lomba", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1987,06,21), Nacionalidade="Portugal", Altura=1.74, Peso=80.8, Fotografia="JoaoLomba.jpg", EquipaPK=7  },
               new Jogadores {ID=64, Nome="Pedro Martins", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1995,05,18), Nacionalidade="Portugal", Altura=1.73, Peso=77.0, Fotografia="PedroMartins.jpg", EquipaPK=7  },
               new Jogadores {ID=65, Nome="Jo�o Sardo", Posicao="Avan�ado", DataNascimento=new DateTime(1996,02,15), Nacionalidade="Portugal", Altura=1.81, Peso=76.2, Fotografia="Jo�oSardo.jpg", EquipaPK=7  },
               new Jogadores {ID=66, Nome="Ivo Silva", Posicao="Avan�ado", DataNascimento=new DateTime(1990,04,01), Nacionalidade="Portugal", Altura=1.80, Peso=79.3, Fotografia="IvoSilva.jpg", EquipaPK=7  },
               new Jogadores {ID=67, Nome="Paulo Passos", Posicao="Avan�ado", DataNascimento=new DateTime(1990,11,24), Nacionalidade="Portugal",  Altura=1.83, Peso=78.3, Fotografia="PauloPassos.jpg", EquipaPK=7  },
               new Jogadores {ID=68, Nome="Hern�ni Diniz", Posicao="Avan�ado", DataNascimento=new DateTime(1994,10,09), Nacionalidade="Portugal", Altura=1.81, Peso=79.4, Fotografia="HernaniDiniz.jpg", EquipaPK=7  },
               new Jogadores {ID=69, Nome="Jo�o Alves (Joka)", Posicao="Avan�ado", DataNascimento=new DateTime(1993,05,27), Nacionalidade="Portugal", Altura=1.78, Peso=71.2, Fotografia="Joka.jpg", EquipaPK=7  },
               new Jogadores {ID=70, Nome="Alexandre Marques (Xanoca)", Posicao="Avan�ado", DataNascimento=new DateTime(1994,08,02), Nacionalidade="Portugal", Altura=1.80,Peso=72.0, Fotografia="Xanoca.jpg", EquipaPK=7  },
               //OC Barcelos 
               new Jogadores {ID=71, Nome="Ricardo Silva", Posicao="Guarda Redes", DataNascimento=new DateTime(1983,03,10), Nacionalidade="Portugal", Altura=1.71, Peso=81.1, Fotografia="RicardoSilva.jpg", EquipaPK=8 },
               new Jogadores {ID=72, Nome="Andr� Almeida", Posicao="Guarda Redes", DataNascimento=new DateTime(1987,04,07), Nacionalidade="Portugal", Altura=1.76, Peso=83.3, Fotografia="AndreAlmeida.jpg", EquipaPK=8 },
               new Jogadores {ID=73, Nome="Juan Garc�a", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1991,03,25), Nacionalidade="Espanha", Altura=1.83, Peso=78, Fotografia="JuanGarcia.jpg", EquipaPK=8 },
               new Jogadores {ID=74, Nome="Z� Pedro", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1997,02,19), Nacionalidade="Portugal",  Altura=1.76, Peso=75, Fotografia="ZePedro.jpg", EquipaPK=8 },
               new Jogadores {ID=75, Nome="Afonso Lima", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1985,04,27), Nacionalidade="Portugal", Altura=1.84, Peso=78, Fotografia="AfonsoLima.jpg", EquipaPK=8 },
               new Jogadores {ID=76, Nome="R�ben Sousa", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1992,06,02), Nacionalidade="Portugal", Altura=1.79, Peso=76, Fotografia="RubenSousa.jpg", EquipaPK=8 },
               new Jogadores {ID=77, Nome="Jo�o Almeida", Posicao="Avan�ado", DataNascimento=new DateTime(1995,05,07), Nacionalidade="Portugal" , Altura=1.82, Peso=83, Fotografia="JoaoAlmeida.jpg", EquipaPK=8 },
               new Jogadores {ID=78, Nome="Jo�o Guimar�es", Posicao="Avan�ado", DataNascimento=new DateTime(1991,10,07), Nacionalidade="Portugal", Altura=1.86, Peso=82, Fotografia="JoaoGuimaraes.jpg", EquipaPK=8 },
               new Jogadores {ID=79, Nome="Hugo Costa", Posicao="Avan�ado", DataNascimento=new DateTime(1988,05,05), Nacionalidade="Portugal", Altura=1.73, Peso=76, Fotografia="HugoCosta.jpg", EquipaPK=8 },
               new Jogadores {ID=80, Nome="M�rio Rodrigues", Posicao="Avan�ado", DataNascimento=new DateTime(1990,12,23), Nacionalidade="Mo�ambique", Altura=1.75,Peso=78, Fotografia="MarioRodrigues.jpg", EquipaPK=8 },
               //Turquel
               new Jogadores {ID=81, Nome="Samuel Santos", Posicao="Guarda Redes", DataNascimento=new DateTime(1989,10,23), Nacionalidade="Portugal", Altura=1.83, Peso=83, Fotografia="SamuelSantos.jpg", EquipaPK=9  },
               new Jogadores {ID=82, Nome="Marco Barros", Posicao="Guarda Redes", DataNascimento=new DateTime(1985,01,01), Nacionalidade="Portugal", Altura=1.77, Peso=80, Fotografia="MarcoBarros.jpg", EquipaPK=9  },
              new Jogadores {ID=83, Nome="Daniel Matias", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1987,10,19), Nacionalidade="Portugal", Altura=1.74, Peso=69, Fotografia="DanielMatias.jpg", EquipaPK=9  },
               new Jogadores {ID=84, Nome="Lu�s Silva", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1989,10,21), Nacionalidade="Portugal", Altura=1.79, Peso=82, Fotografia="LuisSilva.jpg", EquipaPK=9  },
               new Jogadores {ID=85, Nome="Andr� Pimenta", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1993,02,24), Nacionalidade="Portugal", Altura=1.75, Peso=72, Fotografia="AndrePimenta.jpg", EquipaPK=9  },
               new Jogadores {ID=86, Nome="Pedro Vaz", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1992,01,12), Nacionalidade="Portugal", Altura=1.81, Peso=78, Fotografia="PedroVaz.jpg", EquipaPK=9  },
               new Jogadores {ID=87, Nome="Andr� Moreira", Posicao="Avan�ado", DataNascimento=new DateTime(1984,06,03), Nacionalidade="Portugal", Altura=1.82, Peso=80, Fotografia="AndreMoreira.jpg", EquipaPK=9  },
               new Jogadores {ID=88, Nome="Vasco Lu�s", Posicao="Avan�ado", DataNascimento=new DateTime(1987,09,07), Nacionalidade="Portugal", Altura=1.74, Peso=72, Fotografia="VascoLuis.jpg", EquipaPK=9  },
               new Jogadores {ID=89, Nome="Jo�o Silva", Posicao="Avan�ado", DataNascimento=new DateTime(1992,02,19), Nacionalidade="Portugal", Altura=1.79, Peso=75, Fotografia="JoaoSilva.jpg", EquipaPK=9  },
               new Jogadores {ID=90, Nome="Tiago Mateus", Posicao="Avan�ado", DataNascimento=new DateTime(1998,10,10), Nacionalidade="Portugal", Altura=1.77, Peso=74, Fotografia="TiagoMateus.jpg", EquipaPK=9  },
               //Pa�o de Arcos
               new Jogadores {ID=100, Nome="Diogo Rodrigues", Posicao="Guarda Redes", DataNascimento=new DateTime(1994,04,04), Nacionalidade="Portugal", Altura=1.82, Peso=81, Fotografia="DiogoRodrigues.jpg", EquipaPK=10  },
               new Jogadores {ID=101, Nome="Diogo Almeida ", Posicao="Guarda Redes", DataNascimento=new DateTime(1987,09,23), Nacionalidade="Portugal", Altura=1.78, Peso=83, Fotografia="DiogoAlmeida.jpg", EquipaPK=10  },
               new Jogadores {ID=102, Nome="Tiago Gouveia", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1996,05,02), Nacionalidade="Portugal", Altura=1.81, Peso=79, Fotografia="TiagoGouveia.jpg", EquipaPK=10  },
               new Jogadores {ID=103, Nome="Gon�alo Nunes", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1998,11,01), Nacionalidade="Portugal", Altura=1.76, Peso=72, Fotografia="GoncaloNunes.jpg", EquipaPK=10  },
               new Jogadores {ID=104, Nome="Rui Pereira", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1983,04,25), Nacionalidade="Portugal",  Altura=1.78, Peso=73, Fotografia="RuiPereira.jpg", EquipaPK=10  },
               new Jogadores {ID=105, Nome="Andr� Centeno", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1986,03,22), Nacionalidade="Angola", Altura=1.80, Peso=81, Fotografia="AndreCenteno.jpg", EquipaPK=10 },
               new Jogadores {ID=106, Nome="N�lson Ribeiro", Posicao="Avan�ado", DataNascimento=new DateTime(1985,09,18), Nacionalidade="Portugal",  Altura=1.79, Peso=78, Fotografia="NelsonRibeiro.jpg", EquipaPK=10  },
               new Jogadores {ID=107, Nome="Daniel Homem", Posicao="Avan�ado", DataNascimento=new DateTime(1989,06,25), Nacionalidade="Portugal"  , Altura=1.73, Peso=76, Fotografia="DanielHomem.jpg", EquipaPK=10  },
               new Jogadores {ID=108, Nome="Tiago Losna", Posicao="Avan�ado", DataNascimento=new DateTime(1983,04,18), Nacionalidade="Portugal", Altura=1.82, Peso=83, Fotografia="TiagoLosna.jpg", EquipaPK=10  },
               //Valen�a
               new Jogadores {ID=109, Nome="Rodolfo Sobral", Posicao="Guarda Redes", DataNascimento=new DateTime(1994,10,15), Nacionalidade="Portugal", Altura=1.75, Peso=81,  Fotografia="RodolfoSobral.jpg", EquipaPK=11  },
               new Jogadores {ID=110, Nome="Carlitos", Posicao="Guarda Redes", DataNascimento=new DateTime(1997,07,23), Nacionalidade="Portugal",  Altura=1.73, Peso=78, Fotografia="Carlitos.jpg", EquipaPK=11 },
               new Jogadores {ID=111, Nome="S�rgio de Jesus", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1987,01,01), Nacionalidade="Portugal", Altura=1.82, Peso=77,  Fotografia="SergioDeJesus.jpg", EquipaPK=11 },
               new Jogadores {ID=112, Nome="Micha", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1984,05,01), Nacionalidade="Portugal", Altura=1.85, Peso=82, Fotografia="Micha.jpg", EquipaPK=11 },
               new Jogadores {ID=113, Nome="Ziga", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1994,05,13), Nacionalidade="Angola", Altura=1.80, Peso=78,  Fotografia="Ziga.jpg", EquipaPK=11 },
               new Jogadores {ID=114, Nome="Tiago Pereira", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1994,05,15), Nacionalidade="Portugal", Altura=1.70, Peso=59,  Fotografia="TiagoPereira.jpg", EquipaPK=11 },
               new Jogadores {ID=115, Nome="H�lder Martins", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1985,09,29), Nacionalidade="Portugal", Altura=1.72, Peso=63,  Fotografia="HelderMartins.jpg", EquipaPK=11 },
               new Jogadores {ID=116, Nome="Guido Oliva", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1992,10,10), Nacionalidade="Argentina", Altura=1.78, Peso=67,  Fotografia="GuidoOliva.jpg", EquipaPK=11 },
               new Jogadores {ID=117, Nome="Lu�s Viana", Posicao="Avan�ado", DataNascimento=new DateTime(1976,06,30), Nacionalidade="Portugal", Altura=1.75, Peso=75,  Fotografia="LuisViana.jpg", EquipaPK=11 },
               new Jogadores {ID=118, Nome="Nuno Pereira", Posicao="Avan�ado", DataNascimento=new DateTime(1995,11,06), Nacionalidade="Portugal", Altura=1.67, Peso=60,  Fotografia="NunoPereira.jpg", EquipaPK=11 },
               new Jogadores {ID=119, Nome="Z� Braga", Posicao="Avan�ado", DataNascimento=new DateTime(1985,03,06), Nacionalidade="Portugal", Altura=1.79, Peso=75,  Fotografia="ZeBraga.jpg", EquipaPK=11 },
               //HC Braga
               new Jogadores {ID=120, Nome="Francisco Veludo", Posicao="Guarda Redes", DataNascimento=new DateTime(1989,10,12), Nacionalidade="Angola", Altura=1.77, Peso=72,  Fotografia="FranciscoVeludo.jpg", EquipaPK=12 },
               new Jogadores {ID=121, Nome="Gabriel Costa", Posicao="Guarda Redes", DataNascimento=new DateTime(1998,04,05), Nacionalidade="Portugal", Altura=1.71, Peso=78,  Fotografia="GabrielCosta.jpg", EquipaPK=12  },
               new Jogadores {ID=122, Nome="Ant�nio Trabulo", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1999,02,25), Nacionalidade="Portugal", Altura=1.72, Peso=59, Fotografia="AntonioTrabulo.jpg", EquipaPK=12  },
               new Jogadores {ID=123, Nome="�ngelo Fernandes", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1989,08,23), Nacionalidade="Portugal", Altura=1.75, Peso=75,  Fotografia="AngeloFernandes.jpg", EquipaPK=12 },
               new Jogadores {ID=124, Nome="M�rcio Rodrigues", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1980,10,10), Nacionalidade="Portugal", Altura=1.78, Peso=76,  Fotografia="MarcioRodrigues.jpg", EquipaPK=12 },
               new Jogadores {ID=125, Nome="Carlos Loureiro", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1997,01,12), Nacionalidade="Portugal", Altura=1.73, Peso=78,  Fotografia="CarlosLoureiro.jpg", EquipaPK=12 },
               new Jogadores {ID=126, Nome="Gon�alo Meira", Posicao="Avan�ado", DataNascimento=new DateTime(1998,05,11), Nacionalidade="Portugal", Altura=1.76, Peso=65,  Fotografia="GoncaloMeira.jpg", EquipaPK=12 },
               new Jogadores {ID=127, Nome="Gon�alo Su�ssas", Posicao="Avan�ado", DataNascimento=new DateTime(1986,04,01), Nacionalidade="Portugal", Altura=1.81, Peso=74,  Fotografia="Gon�aloSuissas.jpg", EquipaPK=12 },
               new Jogadores {ID=128, Nome="Pedro Delgado", Posicao="Avan�ado", DataNascimento=new DateTime(1993,12,18), Nacionalidade="Portugal", Altura=1.73, Peso=98,  Fotografia="PedroDelgado.jpg", EquipaPK=12 },
               new Jogadores {ID=129, Nome="Tom�s Castanheira", Posicao="Avan�ado", DataNascimento=new DateTime(1992,03,26), Nacionalidade="Portugal", Altura= 1.73, Peso=68,  Fotografia="TomasCastanheira.jpg", EquipaPK=12 },
               new Jogadores {ID=130, Nome="Mateo Molina", Posicao="Avan�ado", DataNascimento=new DateTime(1999,08,26), Nacionalidade="Col�mbia", Altura=1.78, Peso=72,  Fotografia="MateoMolina.jpg", EquipaPK=12 },
               //Infante Sagres
               new Jogadores {ID=131, Nome="Jo�o Ferreira", Posicao="Guarda Redes", DataNascimento=new DateTime(1990,03,02), Nacionalidade="Portugal", Altura=1.79, Peso=83, Fotografia="JoaoFerreira.jpg", EquipaPK=13 },
               new Jogadores {ID=132, Nome="Pedro Maia", Posicao="Guarda Redes", DataNascimento=new DateTime(1989,05,10), Nacionalidade="Portugal", Altura=1.78, Peso=82,  Fotografia="PedroMaia.jpg", EquipaPK=13 },
               new Jogadores {ID=133, Nome="Jo�o Pinheiro", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1997,08,09), Nacionalidade="Portugal", Altura=1.80, Peso=75,  Fotografia="JoaoPinheiro.jpg", EquipaPK=13  },
               new Jogadores {ID=134, Nome="Celso Silva", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1987,04,23), Nacionalidade="Portugal",  Altura=1.79, Peso=76,  Fotografia="CelsoSilva.jpg", EquipaPK=13 },
               new Jogadores {ID=135, Nome="Tiago Ferraz", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1986,02,12), Nacionalidade="Portugal", Altura=1.85, Peso=81,  Fotografia="TiagoFerraz.jpg", EquipaPK=13 },
               new Jogadores {ID=136, Nome="Tiago Pinheiro", Posicao="Avan�ado", DataNascimento=new DateTime(1985,05,24), Nacionalidade="Portugal", Altura=1.83, Peso=77, Fotografia="TiagoPinheiro.jpg", EquipaPK=13 },
               new Jogadores {ID=137, Nome="Carlos Andr�", Posicao="Avan�ado", DataNascimento=new DateTime(1992,07,31), Nacionalidade="Portugal", Altura=1.76, Peso=71,  Fotografia="CarlosAndre.jpg", EquipaPK=13 },
               new Jogadores {ID=138, Nome="Jo�o Campelo", Posicao="Avan�ado", DataNascimento=new DateTime(1997,01,28), Nacionalidade="Portugal", Altura=1.82, Peso=78,  Fotografia="JoaoCampelo.jpg", EquipaPK=13 },
               new Jogadores {ID=139, Nome="Bruno Fernandes", Posicao="Avan�ado", DataNascimento=new DateTime(1982,02,20), Nacionalidade="Portugal", Altura=1.81, Peso=77, Fotografia="BrunoFernandes.jpg", EquipaPK=13 },
               new Jogadores {ID=140, Nome="Jo�o Candeias", Posicao="Avan�ado", DataNascimento=new DateTime(1993,10,10), Nacionalidade="Portugal", Altura=1.76,Peso=75,  Fotografia="JoaoCandeias.jpg", EquipaPK=13 },
               //Gr�ndola
               new Jogadores {ID=141, Nome="Marcelo Bento", Posicao="Guarda Redes", DataNascimento=new DateTime(1987,07,12), Nacionalidade="Portugal", Altura=1.74, Peso=78.7,  Fotografia="MarceloBento.jpg", EquipaPK=14 },
               new Jogadores {ID=142, Nome="Ricardo Costa", Posicao="Guarda Redes", DataNascimento=new DateTime(1983,02,20), Nacionalidade="Portugal", Altura=1.76, Peso=87.8,  Fotografia="RicardoCosta.jpg", EquipaPK=14 },
               new Jogadores {ID=143, Nome="Ant�nio Pereira", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1989,09,01), Nacionalidade="Portugal", Altura=1.76, Peso=81.1,  Fotografia="AntonioPereira.jpg", EquipaPK=14 },
               new Jogadores {ID=144, Nome="M�rcio Rosa", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1991,07,31), Nacionalidade="Portugal", Altura=1.81, Peso=80.9,  Fotografia="MarcioRosa.jpg", EquipaPK=14 },
               new Jogadores {ID=145, Nome="Filipe Bernardino", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1989,08,28), Nacionalidade="Portugal", Altura=1.77, Peso=76.7,  Fotografia="FilipeBernardino.jpg", EquipaPK=14 },
               new Jogadores {ID=146, Nome="R�ben Silva", Posicao="Defesa/M�dio", DataNascimento=new DateTime(1987,03,05), Nacionalidade="Portugal", Altura=1.79, Peso=82.1,  Fotografia="RubenSilva.jpg", EquipaPK=14 },
               new Jogadores {ID=147, Nome="Jos� Gon�alves", Posicao="Avan�ado", DataNascimento=new DateTime(1991,05,04), Nacionalidade="Portugal", Altura=1.83, Peso=72.0,  Fotografia="JoseGonsalves.jpg", EquipaPK=14 },
               new Jogadores {ID=148, Nome="Hugo dos Santos", Posicao="Avan�ado", DataNascimento=new DateTime(1987,10,29), Nacionalidade="Portugal", Altura=1.69,Peso=64.8,  Fotografia="HugoSantos.jpg", EquipaPK=14 },
               new Jogadores {ID=149, Nome="Jo�o Pereira", Posicao="Avan�ado", DataNascimento=new DateTime(1991,09,27), Nacionalidade="Portugal", Altura=1.81,Peso=82.6,  Fotografia="JoaoPereira.jpg", EquipaPK=14 },
               new Jogadores {ID=150, Nome="Jos� Bernardo", Posicao="Avan�ado", DataNascimento=new DateTime(1997,01,25), Nacionalidade="Portugal", Altura=1.78,Peso=77.3,  Fotografia="JoseBernardo.jpg", EquipaPK=14 },

               };
            jogadores.ForEach(jj => context.Jogadores.AddOrUpdate(j => j.ID, jj));
            context.SaveChanges();

            //***************************************************************************************************************
            // adiciona TORNEIOS
            var torneios = new List<Torneios> {
                new Torneios {ID=1, Nome=" Campeonato Nacional", ListaDeEquipas = new List<Equipas>{equipas[0], equipas[1], equipas[2], equipas[3], equipas[4], equipas[5], equipas[6], equipas[7], equipas[8], equipas[9], equipas[10], equipas[11], equipas[12], equipas[13]}},
                new Torneios {ID=2, Nome=" Ta�a de Portugal", ListaDeEquipas = new List<Equipas>{equipas[0],equipas[1],equipas[2], equipas[3], equipas[4], equipas[5], equipas[6], equipas[7], equipas[8], equipas[9], equipas[10], equipas[11], equipas[12], equipas[13]}},
                new Torneios {ID=3, Nome=" Superta�a Ant�nio Livramento", ListaDeEquipas = new List<Equipas>{equipas[2],equipas[6]}}

            };
            torneios.ForEach(tt => context.Torneios.AddOrUpdate(t => t.ID, tt));
            context.SaveChanges();

            //***************************************************************************************************************
            //adiciona UTILIZADORES
            var utilizadores = new List<Utilizadores>{
                new Utilizadores {ID=1, Username="jcarloslopes3@hotmail.com", NomeCompleto="Jos� Carlos Lopes", Email="jcarloslopes@hotmail.com", ContactoTelefonico="910352191", DataNascimento= new DateTime(1980,03,25)},
                new Utilizadores {ID=2, Username="ananunesrib9@gmail.com", NomeCompleto="Ana Nunes Ribeiro", Email="ananunesrib@gmail.com", ContactoTelefonico="967892213", DataNascimento= new DateTime(1986,09,17)},
                new Utilizadores {ID=3, Username="ralvesferreira3@hotmail.com", NomeCompleto="Ricardo Alves Ferreira", Email="ralvesferreira3@hotmail.com", ContactoTelefonico="912374562", DataNascimento= new DateTime(1979,10,09)},
            };
            utilizadores.ForEach(uu => context.Utilizadores.AddOrUpdate(u => u.ID, uu));
            context.SaveChanges();

            //*************************************************************************************************************
            // adiciona NOTICIAS
            var noticias = new List<Noticias>{
                new Noticias {ID=1, Titulo="FC Porto x Sporting com lota��o esgotada", Conteudo="Menos de duas horas. Foi o tempo que bastou para os bilhetes da meia final da Liga Europeia, entre FC Porto e Sporting, esgotarem no Drag�o Caixa." +
                "Segundo anunciou o FC Porto, os ingressos que foram colocados � venda na manh� desta quarta-feira est�o j� completamente esgotados, para aquele que ser� o primeiro jogo da final four da Liga Europeia que o Drag�o Caixa organizar�." +
                "O jogo entre FC Porto e Sporting est� agendado para as 12h30, enquanto que tr�s horas depois h� lugar para o Barcelona x Reus, jogo para o qual ainda existem bilhetes dispon�veis. Para domingo, �s 12h30, est� agendada a final da competi��o.", Data=new DateTime(2018,05,09), Fotografia="Noticia1.jpg", UtilizadorPK=1, ListaDeEquipas = new List<Equipas>{equipas[1], equipas[2]}},
                new Noticias {ID=2, Titulo="Benfica cola-se ao FC Porto na lideran�a", Conteudo="Num final de semana marcado pelo empate do Sporting em Barcelos (2x2), o Benfica terminou com a jornada 22 com um triunfo, em casa, por 5x2, perante a Oliveirense, colando-se ao FC Porto na lideran�a do campeonato." +
                "A vit�ria come�ou a desenhar-se logo na primeira parte, com uma metade inicial demolidora dos encarnados. Um hattrick de Jo�o Rodrigues e um golo de Diogo Rafael levaram o Benfica a vencer por 4x0 para o intervalo. " +
                "Na segunda parte, a Oliveirense ainda encurtou a vantagem encarnada para 4x2, por Ricardo Barreiros e Nuno Ara�jo, aproveitando o desperd�cio encarnado, que falhara dois pen�ltis e um livre direto at� ent�o. At� final, destaque para o fechar de contas por Diogo Rafael." +
                "Na pr�xima jornada, o Benfica continua com o calend�rio dif�cil: o jogo � no Drag�o Caixa, daqui a duas semanas. J� a Oliveirense recebe o Turquel.", Data=new DateTime(2018,05,07), Fotografia="Noticia2.jpg",  UtilizadorPK=1, ListaDeEquipas = new List<Equipas>{equipas[0], equipas[2]}},
                new Noticias {ID=3, Titulo="Sporting escorrega em Barcelos e complica contas do t�tulo", Conteudo="O Sporting n�o passou no Municipal de Barcelos! Num dos jogos grandes da 22� jornada da 1� Divis�o, os le�es n�o foram al�m de um empate (2x2) frente ao �quei Clube de Barcelos, podendo terminar a ronda na terceira posi��o." +
                "Os visitantes entraram melhor no jogo, chegando ao primeiro golo logo aos quatro minutos, por V�tor Hugo. O conjunto da casa reagiu e conseguiu a igualdade por Juanjo, aos 11�." +
                "No segundo tempo, o Sporting voltou a entrar melhor, voltando a conseguir mexer no marcador, com o segundo tento de V�tor Hugo. A quatro minutos do final, o conjunto orientado por Paulo Pereira restabeleceu o empate por Marinho, com a divis�o de pontos a verificar-se no final.", Data=new DateTime(2018,05,06), Fotografia="Noticia3.jpg",  UtilizadorPK=2, ListaDeEquipas = new List<Equipas>{equipas[1], equipas[7]}},
                new Noticias {ID=4, Titulo="Xanoca fica sem jogar 2 meses mas castigo era de 1 ano", Conteudo="Xanoca, do SC Tomar, n�o voltar� a jogar esta temporada devido a um castigo aplicado pelo Conselho de Disciplina da Federa��o de Patinagem de Portugal. " +
             "Mas o caso � ins�lito. O castigo de um ano de suspens�o foi dado como iniciado a 30 de junho de 2017, mas s� esta sexta-feira � que foi dado a conhecer, o que significa que Xanoca esteve a jogar durante o periodo em que era suposto estar castigado." +
             "Desta forma, uma vez que o castigo apenas foi anunciado esta sexta-feira, Xanoca vai cumprir apenas cerca de dois meses de suspens�o, falhando as cinco jornadas finais do campeonato, mais a final-four da Ta�a de Portugal, na qual o SC Tomar tem encontro marcado com a AD Valongo nas meias-finais." +
             "O caso remonta � temporada passada, em que Xanoca � acusado de em tr�s momentos distintos � quarto trimestre de 2016 e primeiro e terceiro de trimestres de 2017 - n�o ter comunicado a sua localiza��o para um eventual controlo antidopagem, algo obrigat�rio para os jogadores que est�o em via de poderem representar as sele��es nacionais." +
             "No entanto, Xanoca ter� enviado a informa��o acerca da sua localiza��o para o Conselho Nacional Antidopagem mas em ficheiros n�o aceites pela autoridade de antidopagem, o que na pr�tica levou � imposi��o do castigo de um ano sem competi��o devido a �neglig�ncia�. Uma suspens�o proposta pelo Conselho Nacional Antidopagem e acatada pelo Conselho de Disciplina da Federa��o de Patinagem de Portugal, embora a federa��o tenha proposto apenas uma advert�ncia ao jogador." +
             "O caso remonta ainda ao per�odo em que Xanoca representava o HC Turquel, tendo assinado pelo SC Tomar no in�cio da presente temporada, na qual acabou por disputar 28 jogos e apontar cinco golos. Entretanto, o jogador tem j� acordo para continuar a representar os nabantinos na �poca quem", Data=new DateTime(2018,05,05), Fotografia="Noticia4.jpg", UtilizadorPK=3, ListaDeEquipas = new List<Equipas>{equipas[6]}},
                new Noticias {ID=5, Titulo="Guilherme Silva: �Lutaremos pelo 5.� lugar at� final�", Conteudo="S�o 32 os pontos que separam a AD Valongo do Gr�ndola, quinto e �ltimo classificados, respetivamente. As duas equipas medem for�as este s�bado, em partida referente � 22.� jornada do campeonato, e Guilherme Silva, hoquista dos valonguenses, aponta � conquista dos tr�s pontos para o objetivo de segurar o quinto lugar ficar mais perto." +
                "�Em casa somos uma equipa muito forte, estamos na reta final do campeonato e queremos acab�-lo da melhor maneira�, afirmou Guilherme Silva. " +
                "�Pensamos jogo a jogo e em conquistar os tr�s pontos. O nosso objetivo � o quinto lugar e vamos lutar por ele at� final�, acrescentou o avan�ado valonguense, que garantiu que esta forma de pensar vai ser posta em pr�tica diante do Gr�ndola.�O Gr�ndola � uma equipa que est� a lutar pela manuten��o e sabemos que vai dar tudo para a conseguir. No jogo da primeira volta criou-nos dificuldades, mas estamos a preparar-nos bem para conquistar os tr�s pontos�." +
                "Autor de nove golos esta �poca, sete no campeonato e dois na Ta�a de Portugal, Guilherme Silva, que cumpre a segunda temporada na AD Valongo, est� satisfeito com o trabalho que a equipa tem vindo a fazer e diz sentir-se a evoluir a n�vel pessoal." +
                "�Sinto que estou a crescer de dia para dia. Os m�todos de trabalho aqui s�o muito bons, o que faz com que os jogadores evoluam muito. A n�vel de campeonato sinto que estou a fazer uma boa �poca, tenho ajudado sempre a equipa e vou continuar a faz�-lo at� ao final�, finalizou o jogador que tem tamb�m como objetivo tentar conquistar a Ta�a de Portugal, uma vez que a AD Valongo ainda est� em prova, tendo encontro marcado com o SC Tomar nas meias-finais.", Data=new DateTime(2018,05,18), Fotografia="Noticia5.jpg", UtilizadorPK=2, ListaDeEquipas = new List<Equipas>{equipas[10]}},
            };
            noticias.ForEach(nn => context.Noticias.AddOrUpdate(n => n.ID, nn));
            context.SaveChanges();

            


        }
    }
}

