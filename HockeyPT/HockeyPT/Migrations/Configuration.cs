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
               new Equipas {ID=10, Nome="Paço de Arcos",Logotipo="PacoArcos.jpg",  Cidade="Paço de Arcos" },
               new Equipas {ID=11, Nome="Valença" ,Logotipo="Valenca.jpg", Cidade="Valença" },
               new Equipas {ID=12, Nome="HC Braga" ,Logotipo="Braga.jpg",  Cidade="Braga" },
               new Equipas {ID=13, Nome="Infante Sagres",Logotipo="InfanteSagres.jpg",  Cidade="Porto" },
               new Equipas {ID=14, Nome="Grândola" , Logotipo="Grandola.jpg",  Cidade="Grândola" }
            };
            equipas.ForEach(ee => context.Equipas.AddOrUpdate(e => e.ID, ee));
            context.SaveChanges();

            //*********************************************************************************************************************
            // adiciona Jogadores
            var jogadores = new List<Jogadores> {
                //Benfica
               new Jogadores {ID=1, Nome="Pedro Henriques", Posicao="Guarda Redes", DataNascimento= new DateTime(1990,09,27), Nacionalidade="Portugal", Altura=1.86 , Peso=82.0, Fotografia="PedroHenriques.jpg", EquipaPK=1 },
               new Jogadores {ID=2, Nome="Guillem Trabal", Posicao="Guarda Redes", DataNascimento=new DateTime(1979,06,11), Nacionalidade="Espanha", Altura=1.85, Peso=80.3, Fotografia="GuillemTrabal.jpg", EquipaPK=1  },
               new Jogadores {ID=3, Nome="Valter Neves", Posicao="Defesa/Médio", DataNascimento=new DateTime(1983,08,12), Nacionalidade="Portugal", Altura=1.69, Peso=73.5, Fotografia="ValterNeves.jpg", EquipaPK=1  },
               new Jogadores {ID=4, Nome="Diogo Rafael", Posicao="Defesa/Médio", DataNascimento=new DateTime(1989,11,17), Nacionalidade="Portugal", Altura=1.71, Peso=79.2, Fotografia="DiogoRafael.jpg", EquipaPK=1  },
               new Jogadores {ID=5, Nome="Miguel Vieira", Posicao="Defesa/Médio", DataNascimento=new DateTime(1996,09,05), Nacionalidade="Portugal",Altura=1.70, Peso=76.7, Fotografia="MiguelVieira.jpg", EquipaPK=1  },
               new Jogadores {ID=6, Nome="Tiago Rafael", Posicao="Defesa/Médio", DataNascimento=new DateTime(1983,09,09), Nacionalidade="Portugal", Altura=1.75, Peso=82.9, Fotografia="TiagoRafael.jpg", EquipaPK=1  },
               new Jogadores {ID=7, Nome="Jordi Adroher", Posicao="Avançado", DataNascimento=new DateTime(1984,11,22), Nacionalidade="Espanha", Altura=1.73, Peso=72.0, Fotografia="JordiAdroher.jpg", EquipaPK=1  },
               new Jogadores {ID=8, Nome="Miguel Rocha", Posicao="Avançado", DataNascimento=new DateTime(1993,01,05), Nacionalidade="Portugal", Altura=1.85, Peso=80.1, Fotografia="MiguelRocha.jpg", EquipaPK=1 },
               new Jogadores {ID=9, Nome="Carlos Nicolía", Posicao="Avançado", DataNascimento=new DateTime(1986,04,04), Nacionalidade="Argentina", Altura=1.80, Peso=79.0, Fotografia="CarlosNicolia.jpg", EquipaPK=1 },
               new Jogadores {ID=10, Nome="João Rodrigues", Posicao="Avançado", DataNascimento=new DateTime(1990,07,15), Nacionalidade="Portugal", Altura=1.85, Peso=84.4, Fotografia="JoaoRodrigues.jpg", EquipaPK=1 },
               //Sporting
               new Jogadores {ID=11, Nome="Ângelo Girão", Posicao="Guarda Redes", DataNascimento=new DateTime(1989,08,28), Nacionalidade="Portugal", Altura=1.76, Peso=87.2, Fotografia="AngeloGirao.jpg", EquipaPK=2 },
               new Jogadores {ID=12, Nome="Zé Diogo Macedo", Posicao="Guarda Redes", DataNascimento=new DateTime(1993,07,17), Nacionalidade="Portugal", Altura=1.78, Peso=86.5, Fotografia="ZeDiogoMacedo.jpg", EquipaPK=2 },
               new Jogadores {ID=13, Nome="Ferran Font", Posicao="Defesa/Médio", DataNascimento=new DateTime(1996,11,12), Nacionalidade="Espanha", Altura=1.70, Peso=82.7, Fotografia="FerranFont.jpg", EquipaPK=2 },
               new Jogadores {ID=14, Nome="Matías Platero", Posicao="Defesa/Médio", DataNascimento=new DateTime(1988,01,17), Nacionalidade="Argentina", Altura=1.86, Peso=81.1, Fotografia="MatiasPlatero.jpg", EquipaPK=2 },
               new Jogadores {ID=15, Nome="Caio", Posicao="Defesa/Médio", DataNascimento= new DateTime(1982,01,05), Nacionalidade="Portugal", Altura=1.79, Peso=78.0, Fotografia="Caio.jpg", EquipaPK=2  },
               new Jogadores {ID=16, Nome="Henrique Magalhães", Posicao="Defesa/Médio", DataNascimento=new DateTime(1991,10,22), Nacionalidade="Portugal", Altura=1.85, Peso=79.0, Fotografia="HenriqueMagalhaes.jpg", EquipaPK=2  },
               new Jogadores {ID=17, Nome="Pedro Gil", Posicao="Avançado", DataNascimento=new DateTime(1980,04,26), Nacionalidade="Espanha", Altura=1.87, Peso=83.8, Fotografia="PedroGil.jpg", EquipaPK=2 },
               new Jogadores {ID=18, Nome="João Pinto", Posicao="Avançado", DataNascimento=new DateTime(1987,01,28), Nacionalidade="Angola", Altura=1.75, Peso=78.3, Fotografia="JoaoPinto.jpg", EquipaPK=2 },
               new Jogadores {ID=19, Nome="Vítor Hugo", Posicao="Avançado", DataNascimento=new DateTime(1984,10,23), Nacionalidade="Portugal", Altura=1.81, Peso=85.4, Fotografia="VitorHugo.jpg", EquipaPK=2 },
               new Jogadores {ID=20, Nome="Toni Pérez", Posicao="Avançado", DataNascimento=new DateTime(1990,06,07), Nacionalidade="Espanha", Altura=1.78, Peso=76.0, Fotografia="ToniPerez.jpg", EquipaPK=2 },
                //FC Porto
                new Jogadores {ID=21, Nome="Carles Grau", Posicao="Guarda Redes", DataNascimento=new DateTime(1990,03,10), Nacionalidade="Espanha", Altura=1.78, Peso=74.5, Fotografia="CarlesGrau.jpg", EquipaPK=3  },
               new Jogadores {ID=22, Nome="Nélson Filipe", Posicao="Guarda Redes", DataNascimento=new DateTime(1984,11,05), Nacionalidade="Portugal", Altura=1.75, Peso=78.2, Fotografia="NelsonFilipe.jpg", EquipaPK=3   },
               new Jogadores {ID=23, Nome="João Lima", Posicao="Defesa/Médio", DataNascimento=new DateTime(1990,03,10), Nacionalidade="Espanha", Altura=1.86, Peso=87.4, Fotografia="JoaoLima.jpg", EquipaPK=3   },
               new Jogadores {ID=24, Nome="Ton Baliu", Posicao="Defesa/Médio", DataNascimento=new DateTime(1989,01,13), Nacionalidade="Espanha", Altura=1.84, Peso=83.0, Fotografia="TonBaliu.jpg", EquipaPK=3   },
               new Jogadores {ID=25, Nome="Hélder Nunes", Posicao="Defesa/Médio", DataNascimento=new DateTime(1994,02,23), Nacionalidade="Portugal", Altura=1.78, Peso=89.3, Fotografia="HelderNunes.jpg", EquipaPK=3   },
               new Jogadores {ID=26, Nome="Telmo Pinto", Posicao="Defesa/Médio", DataNascimento=new DateTime(1993,01,23), Nacionalidade="Portugal", Altura=1.76, Peso=75.2, Fotografia="TelmoPinto.jpg", EquipaPK=3   },
               new Jogadores {ID=27, Nome="Rafa Costa", Posicao="Avançado", DataNascimento=new DateTime(1991,11,10), Nacionalidade="Portugal", Altura=1.83, Peso=87.2, Fotografia="RafaCosta.jpg", EquipaPK=3   },
               new Jogadores {ID=28, Nome="Alvarinho", Posicao="Avançado", DataNascimento=new DateTime(1996,04,18), Nacionalidade="Portugal", Altura=1.82, Peso=85.4, Fotografia="Alvarinho.jpg", EquipaPK=3   },
               new Jogadores {ID=29, Nome="Jorge Silva", Posicao="Avançado", DataNascimento=new DateTime(1984,05,09), Nacionalidade="Portugal", Altura=1.87, Peso=81.3, Fotografia="JorgeSilva.jpg", EquipaPK=3   },
               new Jogadores {ID=30, Nome="Gonçalo Alves", Posicao="Avançado", DataNascimento=new DateTime(1993,07,26), Nacionalidade="Portugal", Altura=1.78, Peso=80.0, Fotografia="GoncaloAlves.jpg", EquipaPK=3   },
               //UD Oliveirense
               new Jogadores {ID=31, Nome="Domingos Pinho", Posicao="Guarda Redes", DataNascimento=new DateTime(1980,07,15), Nacionalidade="Portugal",  Altura=1.77, Peso=69.1, Fotografia="DomingosPinho.jpg", EquipaPK=4  },
               new Jogadores {ID=32, Nome="Xavier Puigbí", Posicao="Guarda Redes", DataNascimento=new DateTime(1987,05,23), Nacionalidade="Espanha", Altura=1.83, Peso=76.3, Fotografia="XavierPuigbi.jpg", EquipaPK=4  },
               new Jogadores {ID=33, Nome="Nuno Araújo", Posicao="Defesa/Médio", DataNascimento=new DateTime(1988,06,05), Nacionalidade="Moçambique", Altura=1.84, Peso=77.2, Fotografia="NunoAraujo.jpg", EquipaPK=4  },
               new Jogadores {ID=34, Nome="Pedro Moreira", Posicao="Defesa/Médio", DataNascimento=new DateTime(1985,07,17), Nacionalidade="Portugal", Altura=1.78, Peso=70.0, Fotografia="PedroMoreira.jpg", EquipaPK=4  },
               new Jogadores {ID=35, Nome="Jordi Bargalló", Posicao="Defesa/Médio", DataNascimento=new DateTime(1979,12,05), Nacionalidade="Espanha", Altura=1.69, Peso=65.0, Fotografia="JordiBargallo.jpg", EquipaPK=4  },
               new Jogadores {ID=36, Nome="Jordi Burgaya", Posicao="Defesa/Médio", DataNascimento=new DateTime(1995,06,08), Nacionalidade="Espanha", Altura=1.82, Peso=81.4, Fotografia="JordiBurgaya.jpg", EquipaPK=4  },
               new Jogadores {ID=37, Nome="Jepi Selva", Posicao="Avançado", DataNascimento=new DateTime(1985,12,09), Nacionalidade="Espanha", Altura=1.76, Peso=70.3, Fotografia="JepiSelva.jpg", EquipaPK=4  },
               new Jogadores {ID=38, Nome="Pablo Cancela", Posicao="Avançado", DataNascimento=new DateTime(1988,03,08), Nacionalidade="Espanha", Altura=1.71, Peso=68.1, Fotografia="PabloCancela.jpg", EquipaPK=4  },
              new Jogadores {ID=39, Nome="João Souto", Posicao="Avançado", DataNascimento=new DateTime(1992,07,26), Nacionalidade="Portugal", Altura=1.78, Peso=75.7, Fotografia="JoaoSouto.jpg", EquipaPK=4  },
               new Jogadores {ID=40, Nome="Ricardo Barreiros", Posicao="Avançado", DataNascimento=new DateTime(1982,01,17), Nacionalidade="Portugal", Altura=1.81, Peso=79.0, Fotografia="RicardoBarreiros.jpg", EquipaPK=4  },
               //Valongo
               new Jogadores {ID=41, Nome="Rui Mendes", Posicao="Guarda Redes", DataNascimento=new DateTime(1999,03,12), Nacionalidade="Portugal", Altura=1.85, Peso=79.1, Fotografia="RuiMendes.jpg", EquipaPK=5  },
               new Jogadores {ID=42, Nome="Leonardo Pais", Posicao="Guarda Redes", DataNascimento=new DateTime(1990,08,24), Nacionalidade="Portugal", Altura=1.76, Peso=67.2, Fotografia="LeonardoPais.jpg", EquipaPK=5  },
               new Jogadores {ID=43, Nome="Diogo Abreu", Posicao="Defesa/Médio", DataNascimento=new DateTime(2001,03,06), Nacionalidade="Portugal", Altura=1.81, Peso=76.7, Fotografia="DiogoAbreu.jpg", EquipaPK=5  },
               new Jogadores {ID=44, Nome="Xavier Cardoso", Posicao="Defesa/Médio", DataNascimento=new DateTime(1995,02,14), Nacionalidade="Portugal", Altura=1.74, Peso=69.7, Fotografia="XavierCardoso.jpg", EquipaPK=5  },
               new Jogadores {ID=45, Nome="Poka", Posicao="Defesa/Médio", DataNascimento=new DateTime(1989,05,07), Nacionalidade="Portugal", Altura=1.86, Peso=80.1, Fotografia="Poka.jpg", EquipaPK=5  },
               new Jogadores {ID=46, Nome="Pedro Mendes", Posicao="Defesa/Médio", DataNascimento=new DateTime(1993,01,04), Nacionalidade="Portugal", Altura=1.79, Peso=80.2, Fotografia="PedroMendes.jpg", EquipaPK=5  },
               new Jogadores {ID=47, Nome="Luís Melo", Posicao="Avançado", DataNascimento=new DateTime(1996,04,13), Nacionalidade="Portugal", Altura=1.78, Peso=81.2, Fotografia="LuisMelo.jpg", EquipaPK=5  },
               new Jogadores {ID=48, Nome="Gonçalo Neto", Posicao="Avançado", DataNascimento=new DateTime(1988,02,05), Nacionalidade="Portugal" , Altura=1.73, Peso=81.1, Fotografia="GoncaloNeto.jpg", EquipaPK=5  },
               new Jogadores {ID=49, Nome="Guilherme Silva", Posicao="Avançado", DataNascimento=new DateTime(1994,08,24), Nacionalidade="Portugal" , Altura=1.77, Peso=83.2, Fotografia="GuilhermeSilva.jpg", EquipaPK=5  },
               new Jogadores {ID=50, Nome="Rúben Pereira", Posicao="Avançado", DataNascimento=new DateTime(1990,05,09), Nacionalidade="Portugal" , Altura=1.79, Peso=84.1, Fotografia="RubenPereira.jpg", EquipaPK=5  },
               //Juventude de Viana
               new Jogadores {ID=51, Nome="Paulo Matos", Posicao="Guarda Redes", DataNascimento=new DateTime(1973,11,16), Nacionalidade="Portugal" , Altura=1.73, Peso=68.1, Fotografia="PauloMatos.jpg", EquipaPK=6  },
               new Jogadores {ID=52, Nome="Telmo Fernandes", Posicao="Guarda Redes", DataNascimento=new DateTime(1980,07,22), Nacionalidade="Portugal" , Altura=1.82, Peso=78.2, Fotografia="TelmoFernandes.jpg", EquipaPK=6  },
               new Jogadores {ID=53, Nome="Romeu Rocha", Posicao="Defesa/Médio", DataNascimento=new DateTime(1978,02,08), Nacionalidade="Portugal" ,  Altura=1.85, Peso=79.3, Fotografia="RomeuRocha.jpg", EquipaPK=6  },
               new Jogadores {ID=54, Nome="Francisco Silva", Posicao="Defesa/Médio", DataNascimento=new DateTime(1991,05,05), Nacionalidade="Portugal" , Altura=1.74, Peso=71.4, Fotografia="FranciscoSilva.jpg", EquipaPK=6  },
               new Jogadores {ID=55, Nome="Nélson Pereira", Posicao="Defesa/Médio", DataNascimento=new DateTime(1988,08,29), Nacionalidade="Portugal" , Altura=1.71, Peso=68.1, Fotografia="NelsonPereira.jpg", EquipaPK=6  },
               new Jogadores {ID=56, Nome="Nuno Santos", Posicao="Defesa/Médio", DataNascimento=new DateTime(1990,05,02), Nacionalidade="Portugal" , Altura=1.70, Peso=65.3, Fotografia="NunoSantos.jpg", EquipaPK=6  },
               new Jogadores {ID=57, Nome="Gustavo Lima", Posicao="Avançado", DataNascimento=new DateTime(1993,11,13), Nacionalidade="Portugal", Altura=1.72,Peso=69.6, Fotografia="GustavoLima.jpg", EquipaPK=6  },
               new Jogadores {ID=58, Nome="Tó Silva", Posicao="Avançado", DataNascimento=new DateTime(1976,10,07), Nacionalidade="Portugal", Altura=1.83,Peso=74.5, Fotografia="ToSilva.jpg", EquipaPK=6  },
               new Jogadores {ID=59, Nome="André Azevedo", Posicao="Avançado", DataNascimento=new DateTime(1976,03,27), Nacionalidade="Portugal", Altura=1.67, Peso=68.1, Fotografia="AndreAzevedo.jpg", EquipaPK=6  },
               new Jogadores {ID=60, Nome="Emanuel García", Posicao="Avançado", DataNascimento=new DateTime(1983,07,21), Nacionalidade="Argentina", Altura=1.71, Peso=75.0, Fotografia="EmanuelGarcia.jpg", EquipaPK=6  },
               //Sp. Tomar 
               new Jogadores {ID=61, Nome="Marco Gaspar", Posicao="Guarda Redes", DataNascimento=new DateTime(1988,03,18), Nacionalidade="Portugal", Altura=1.75, Peso=73.3, Fotografia="MarcoGaspar.jpg", EquipaPK=7  },
               new Jogadores {ID=62, Nome="Diogo Alves", Posicao="Guarda Redes", DataNascimento=new DateTime(1997,02,04), Nacionalidade="Portugal", Altura=1.78, Peso=79.1, Fotografia="DiogoAlves.jpg", EquipaPK=7  },
               new Jogadores {ID=63, Nome="João Lomba", Posicao="Defesa/Médio", DataNascimento=new DateTime(1987,06,21), Nacionalidade="Portugal", Altura=1.74, Peso=80.8, Fotografia="JoaoLomba.jpg", EquipaPK=7  },
               new Jogadores {ID=64, Nome="Pedro Martins", Posicao="Defesa/Médio", DataNascimento=new DateTime(1995,05,18), Nacionalidade="Portugal", Altura=1.73, Peso=77.0, Fotografia="PedroMartins.jpg", EquipaPK=7  },
               new Jogadores {ID=65, Nome="João Sardo", Posicao="Avançado", DataNascimento=new DateTime(1996,02,15), Nacionalidade="Portugal", Altura=1.81, Peso=76.2, Fotografia="JoãoSardo.jpg", EquipaPK=7  },
               new Jogadores {ID=66, Nome="Ivo Silva", Posicao="Avançado", DataNascimento=new DateTime(1990,04,01), Nacionalidade="Portugal", Altura=1.80, Peso=79.3, Fotografia="IvoSilva.jpg", EquipaPK=7  },
               new Jogadores {ID=67, Nome="Paulo Passos", Posicao="Avançado", DataNascimento=new DateTime(1990,11,24), Nacionalidade="Portugal",  Altura=1.83, Peso=78.3, Fotografia="PauloPassos.jpg", EquipaPK=7  },
               new Jogadores {ID=68, Nome="Hernâni Diniz", Posicao="Avançado", DataNascimento=new DateTime(1994,10,09), Nacionalidade="Portugal", Altura=1.81, Peso=79.4, Fotografia="HernaniDiniz.jpg", EquipaPK=7  },
               new Jogadores {ID=69, Nome="João Alves (Joka)", Posicao="Avançado", DataNascimento=new DateTime(1993,05,27), Nacionalidade="Portugal", Altura=1.78, Peso=71.2, Fotografia="Joka.jpg", EquipaPK=7  },
               new Jogadores {ID=70, Nome="Alexandre Marques (Xanoca)", Posicao="Avançado", DataNascimento=new DateTime(1994,08,02), Nacionalidade="Portugal", Altura=1.80,Peso=72.0, Fotografia="Xanoca.jpg", EquipaPK=7  },
               //OC Barcelos 
               new Jogadores {ID=71, Nome="Ricardo Silva", Posicao="Guarda Redes", DataNascimento=new DateTime(1983,03,10), Nacionalidade="Portugal", Altura=1.71, Peso=81.1, Fotografia="RicardoSilva.jpg", EquipaPK=8 },
               new Jogadores {ID=72, Nome="André Almeida", Posicao="Guarda Redes", DataNascimento=new DateTime(1987,04,07), Nacionalidade="Portugal", Altura=1.76, Peso=83.3, Fotografia="AndreAlmeida.jpg", EquipaPK=8 },
               new Jogadores {ID=73, Nome="Juan García", Posicao="Defesa/Médio", DataNascimento=new DateTime(1991,03,25), Nacionalidade="Espanha", Altura=1.83, Peso=78, Fotografia="JuanGarcia.jpg", EquipaPK=8 },
               new Jogadores {ID=74, Nome="Zé Pedro", Posicao="Defesa/Médio", DataNascimento=new DateTime(1997,02,19), Nacionalidade="Portugal",  Altura=1.76, Peso=75, Fotografia="ZePedro.jpg", EquipaPK=8 },
               new Jogadores {ID=75, Nome="Afonso Lima", Posicao="Defesa/Médio", DataNascimento=new DateTime(1985,04,27), Nacionalidade="Portugal", Altura=1.84, Peso=78, Fotografia="AfonsoLima.jpg", EquipaPK=8 },
               new Jogadores {ID=76, Nome="Rúben Sousa", Posicao="Defesa/Médio", DataNascimento=new DateTime(1992,06,02), Nacionalidade="Portugal", Altura=1.79, Peso=76, Fotografia="RubenSousa.jpg", EquipaPK=8 },
               new Jogadores {ID=77, Nome="João Almeida", Posicao="Avançado", DataNascimento=new DateTime(1995,05,07), Nacionalidade="Portugal" , Altura=1.82, Peso=83, Fotografia="JoaoAlmeida.jpg", EquipaPK=8 },
               new Jogadores {ID=78, Nome="João Guimarães", Posicao="Avançado", DataNascimento=new DateTime(1991,10,07), Nacionalidade="Portugal", Altura=1.86, Peso=82, Fotografia="JoaoGuimaraes.jpg", EquipaPK=8 },
               new Jogadores {ID=79, Nome="Hugo Costa", Posicao="Avançado", DataNascimento=new DateTime(1988,05,05), Nacionalidade="Portugal", Altura=1.73, Peso=76, Fotografia="HugoCosta.jpg", EquipaPK=8 },
               new Jogadores {ID=80, Nome="Mário Rodrigues", Posicao="Avançado", DataNascimento=new DateTime(1990,12,23), Nacionalidade="Moçambique", Altura=1.75,Peso=78, Fotografia="MarioRodrigues.jpg", EquipaPK=8 },
               //Turquel
               new Jogadores {ID=81, Nome="Samuel Santos", Posicao="Guarda Redes", DataNascimento=new DateTime(1989,10,23), Nacionalidade="Portugal", Altura=1.83, Peso=83, Fotografia="SamuelSantos.jpg", EquipaPK=9  },
               new Jogadores {ID=82, Nome="Marco Barros", Posicao="Guarda Redes", DataNascimento=new DateTime(1985,01,01), Nacionalidade="Portugal", Altura=1.77, Peso=80, Fotografia="MarcoBarros.jpg", EquipaPK=9  },
              new Jogadores {ID=83, Nome="Daniel Matias", Posicao="Defesa/Médio", DataNascimento=new DateTime(1987,10,19), Nacionalidade="Portugal", Altura=1.74, Peso=69, Fotografia="DanielMatias.jpg", EquipaPK=9  },
               new Jogadores {ID=84, Nome="Luís Silva", Posicao="Defesa/Médio", DataNascimento=new DateTime(1989,10,21), Nacionalidade="Portugal", Altura=1.79, Peso=82, Fotografia="LuisSilva.jpg", EquipaPK=9  },
               new Jogadores {ID=85, Nome="André Pimenta", Posicao="Defesa/Médio", DataNascimento=new DateTime(1993,02,24), Nacionalidade="Portugal", Altura=1.75, Peso=72, Fotografia="AndrePimenta.jpg", EquipaPK=9  },
               new Jogadores {ID=86, Nome="Pedro Vaz", Posicao="Defesa/Médio", DataNascimento=new DateTime(1992,01,12), Nacionalidade="Portugal", Altura=1.81, Peso=78, Fotografia="PedroVaz.jpg", EquipaPK=9  },
               new Jogadores {ID=87, Nome="André Moreira", Posicao="Avançado", DataNascimento=new DateTime(1984,06,03), Nacionalidade="Portugal", Altura=1.82, Peso=80, Fotografia="AndreMoreira.jpg", EquipaPK=9  },
               new Jogadores {ID=88, Nome="Vasco Luís", Posicao="Avançado", DataNascimento=new DateTime(1987,09,07), Nacionalidade="Portugal", Altura=1.74, Peso=72, Fotografia="VascoLuis.jpg", EquipaPK=9  },
               new Jogadores {ID=89, Nome="João Silva", Posicao="Avançado", DataNascimento=new DateTime(1992,02,19), Nacionalidade="Portugal", Altura=1.79, Peso=75, Fotografia="JoaoSilva.jpg", EquipaPK=9  },
               new Jogadores {ID=90, Nome="Tiago Mateus", Posicao="Avançado", DataNascimento=new DateTime(1998,10,10), Nacionalidade="Portugal", Altura=1.77, Peso=74, Fotografia="TiagoMateus.jpg", EquipaPK=9  },
               //Paço de Arcos
               new Jogadores {ID=100, Nome="Diogo Rodrigues", Posicao="Guarda Redes", DataNascimento=new DateTime(1994,04,04), Nacionalidade="Portugal", Altura=1.82, Peso=81, Fotografia="DiogoRodrigues.jpg", EquipaPK=10  },
               new Jogadores {ID=101, Nome="Diogo Almeida ", Posicao="Guarda Redes", DataNascimento=new DateTime(1987,09,23), Nacionalidade="Portugal", Altura=1.78, Peso=83, Fotografia="DiogoAlmeida.jpg", EquipaPK=10  },
               new Jogadores {ID=102, Nome="Tiago Gouveia", Posicao="Defesa/Médio", DataNascimento=new DateTime(1996,05,02), Nacionalidade="Portugal", Altura=1.81, Peso=79, Fotografia="TiagoGouveia.jpg", EquipaPK=10  },
               new Jogadores {ID=103, Nome="Gonçalo Nunes", Posicao="Defesa/Médio", DataNascimento=new DateTime(1998,11,01), Nacionalidade="Portugal", Altura=1.76, Peso=72, Fotografia="GoncaloNunes.jpg", EquipaPK=10  },
               new Jogadores {ID=104, Nome="Rui Pereira", Posicao="Defesa/Médio", DataNascimento=new DateTime(1983,04,25), Nacionalidade="Portugal",  Altura=1.78, Peso=73, Fotografia="RuiPereira.jpg", EquipaPK=10  },
               new Jogadores {ID=105, Nome="André Centeno", Posicao="Defesa/Médio", DataNascimento=new DateTime(1986,03,22), Nacionalidade="Angola", Altura=1.80, Peso=81, Fotografia="AndreCenteno.jpg", EquipaPK=10 },
               new Jogadores {ID=106, Nome="Nélson Ribeiro", Posicao="Avançado", DataNascimento=new DateTime(1985,09,18), Nacionalidade="Portugal",  Altura=1.79, Peso=78, Fotografia="NelsonRibeiro.jpg", EquipaPK=10  },
               new Jogadores {ID=107, Nome="Daniel Homem", Posicao="Avançado", DataNascimento=new DateTime(1989,06,25), Nacionalidade="Portugal"  , Altura=1.73, Peso=76, Fotografia="DanielHomem.jpg", EquipaPK=10  },
               new Jogadores {ID=108, Nome="Tiago Losna", Posicao="Avançado", DataNascimento=new DateTime(1983,04,18), Nacionalidade="Portugal", Altura=1.82, Peso=83, Fotografia="TiagoLosna.jpg", EquipaPK=10  },
               //Valença
               new Jogadores {ID=109, Nome="Rodolfo Sobral", Posicao="Guarda Redes", DataNascimento=new DateTime(1994,10,15), Nacionalidade="Portugal", Altura=1.75, Peso=81,  Fotografia="RodolfoSobral.jpg", EquipaPK=11  },
               new Jogadores {ID=110, Nome="Carlitos", Posicao="Guarda Redes", DataNascimento=new DateTime(1997,07,23), Nacionalidade="Portugal",  Altura=1.73, Peso=78, Fotografia="Carlitos.jpg", EquipaPK=11 },
               new Jogadores {ID=111, Nome="Sérgio de Jesus", Posicao="Defesa/Médio", DataNascimento=new DateTime(1987,01,01), Nacionalidade="Portugal", Altura=1.82, Peso=77,  Fotografia="SergioDeJesus.jpg", EquipaPK=11 },
               new Jogadores {ID=112, Nome="Micha", Posicao="Defesa/Médio", DataNascimento=new DateTime(1984,05,01), Nacionalidade="Portugal", Altura=1.85, Peso=82, Fotografia="Micha.jpg", EquipaPK=11 },
               new Jogadores {ID=113, Nome="Ziga", Posicao="Defesa/Médio", DataNascimento=new DateTime(1994,05,13), Nacionalidade="Angola", Altura=1.80, Peso=78,  Fotografia="Ziga.jpg", EquipaPK=11 },
               new Jogadores {ID=114, Nome="Tiago Pereira", Posicao="Defesa/Médio", DataNascimento=new DateTime(1994,05,15), Nacionalidade="Portugal", Altura=1.70, Peso=59,  Fotografia="TiagoPereira.jpg", EquipaPK=11 },
               new Jogadores {ID=115, Nome="Hélder Martins", Posicao="Defesa/Médio", DataNascimento=new DateTime(1985,09,29), Nacionalidade="Portugal", Altura=1.72, Peso=63,  Fotografia="HelderMartins.jpg", EquipaPK=11 },
               new Jogadores {ID=116, Nome="Guido Oliva", Posicao="Defesa/Médio", DataNascimento=new DateTime(1992,10,10), Nacionalidade="Argentina", Altura=1.78, Peso=67,  Fotografia="GuidoOliva.jpg", EquipaPK=11 },
               new Jogadores {ID=117, Nome="Luís Viana", Posicao="Avançado", DataNascimento=new DateTime(1976,06,30), Nacionalidade="Portugal", Altura=1.75, Peso=75,  Fotografia="LuisViana.jpg", EquipaPK=11 },
               new Jogadores {ID=118, Nome="Nuno Pereira", Posicao="Avançado", DataNascimento=new DateTime(1995,11,06), Nacionalidade="Portugal", Altura=1.67, Peso=60,  Fotografia="NunoPereira.jpg", EquipaPK=11 },
               new Jogadores {ID=119, Nome="Zé Braga", Posicao="Avançado", DataNascimento=new DateTime(1985,03,06), Nacionalidade="Portugal", Altura=1.79, Peso=75,  Fotografia="ZeBraga.jpg", EquipaPK=11 },
               //HC Braga
               new Jogadores {ID=120, Nome="Francisco Veludo", Posicao="Guarda Redes", DataNascimento=new DateTime(1989,10,12), Nacionalidade="Angola", Altura=1.77, Peso=72,  Fotografia="FranciscoVeludo.jpg", EquipaPK=12 },
               new Jogadores {ID=121, Nome="Gabriel Costa", Posicao="Guarda Redes", DataNascimento=new DateTime(1998,04,05), Nacionalidade="Portugal", Altura=1.71, Peso=78,  Fotografia="GabrielCosta.jpg", EquipaPK=12  },
               new Jogadores {ID=122, Nome="António Trabulo", Posicao="Defesa/Médio", DataNascimento=new DateTime(1999,02,25), Nacionalidade="Portugal", Altura=1.72, Peso=59, Fotografia="AntonioTrabulo.jpg", EquipaPK=12  },
               new Jogadores {ID=123, Nome="Ângelo Fernandes", Posicao="Defesa/Médio", DataNascimento=new DateTime(1989,08,23), Nacionalidade="Portugal", Altura=1.75, Peso=75,  Fotografia="AngeloFernandes.jpg", EquipaPK=12 },
               new Jogadores {ID=124, Nome="Márcio Rodrigues", Posicao="Defesa/Médio", DataNascimento=new DateTime(1980,10,10), Nacionalidade="Portugal", Altura=1.78, Peso=76,  Fotografia="MarcioRodrigues.jpg", EquipaPK=12 },
               new Jogadores {ID=125, Nome="Carlos Loureiro", Posicao="Defesa/Médio", DataNascimento=new DateTime(1997,01,12), Nacionalidade="Portugal", Altura=1.73, Peso=78,  Fotografia="CarlosLoureiro.jpg", EquipaPK=12 },
               new Jogadores {ID=126, Nome="Gonçalo Meira", Posicao="Avançado", DataNascimento=new DateTime(1998,05,11), Nacionalidade="Portugal", Altura=1.76, Peso=65,  Fotografia="GoncaloMeira.jpg", EquipaPK=12 },
               new Jogadores {ID=127, Nome="Gonçalo Suíssas", Posicao="Avançado", DataNascimento=new DateTime(1986,04,01), Nacionalidade="Portugal", Altura=1.81, Peso=74,  Fotografia="GonçaloSuissas.jpg", EquipaPK=12 },
               new Jogadores {ID=128, Nome="Pedro Delgado", Posicao="Avançado", DataNascimento=new DateTime(1993,12,18), Nacionalidade="Portugal", Altura=1.73, Peso=98,  Fotografia="PedroDelgado.jpg", EquipaPK=12 },
               new Jogadores {ID=129, Nome="Tomás Castanheira", Posicao="Avançado", DataNascimento=new DateTime(1992,03,26), Nacionalidade="Portugal", Altura= 1.73, Peso=68,  Fotografia="TomasCastanheira.jpg", EquipaPK=12 },
               new Jogadores {ID=130, Nome="Mateo Molina", Posicao="Avançado", DataNascimento=new DateTime(1999,08,26), Nacionalidade="Colômbia", Altura=1.78, Peso=72,  Fotografia="MateoMolina.jpg", EquipaPK=12 },
               //Infante Sagres
               new Jogadores {ID=131, Nome="João Ferreira", Posicao="Guarda Redes", DataNascimento=new DateTime(1990,03,02), Nacionalidade="Portugal", Altura=1.79, Peso=83, Fotografia="JoaoFerreira.jpg", EquipaPK=13 },
               new Jogadores {ID=132, Nome="Pedro Maia", Posicao="Guarda Redes", DataNascimento=new DateTime(1989,05,10), Nacionalidade="Portugal", Altura=1.78, Peso=82,  Fotografia="PedroMaia.jpg", EquipaPK=13 },
               new Jogadores {ID=133, Nome="João Pinheiro", Posicao="Defesa/Médio", DataNascimento=new DateTime(1997,08,09), Nacionalidade="Portugal", Altura=1.80, Peso=75,  Fotografia="JoaoPinheiro.jpg", EquipaPK=13  },
               new Jogadores {ID=134, Nome="Celso Silva", Posicao="Defesa/Médio", DataNascimento=new DateTime(1987,04,23), Nacionalidade="Portugal",  Altura=1.79, Peso=76,  Fotografia="CelsoSilva.jpg", EquipaPK=13 },
               new Jogadores {ID=135, Nome="Tiago Ferraz", Posicao="Defesa/Médio", DataNascimento=new DateTime(1986,02,12), Nacionalidade="Portugal", Altura=1.85, Peso=81,  Fotografia="TiagoFerraz.jpg", EquipaPK=13 },
               new Jogadores {ID=136, Nome="Tiago Pinheiro", Posicao="Avançado", DataNascimento=new DateTime(1985,05,24), Nacionalidade="Portugal", Altura=1.83, Peso=77, Fotografia="TiagoPinheiro.jpg", EquipaPK=13 },
               new Jogadores {ID=137, Nome="Carlos André", Posicao="Avançado", DataNascimento=new DateTime(1992,07,31), Nacionalidade="Portugal", Altura=1.76, Peso=71,  Fotografia="CarlosAndre.jpg", EquipaPK=13 },
               new Jogadores {ID=138, Nome="João Campelo", Posicao="Avançado", DataNascimento=new DateTime(1997,01,28), Nacionalidade="Portugal", Altura=1.82, Peso=78,  Fotografia="JoaoCampelo.jpg", EquipaPK=13 },
               new Jogadores {ID=139, Nome="Bruno Fernandes", Posicao="Avançado", DataNascimento=new DateTime(1982,02,20), Nacionalidade="Portugal", Altura=1.81, Peso=77, Fotografia="BrunoFernandes.jpg", EquipaPK=13 },
               new Jogadores {ID=140, Nome="João Candeias", Posicao="Avançado", DataNascimento=new DateTime(1993,10,10), Nacionalidade="Portugal", Altura=1.76,Peso=75,  Fotografia="JoaoCandeias.jpg", EquipaPK=13 },
               //Grândola
               new Jogadores {ID=141, Nome="Marcelo Bento", Posicao="Guarda Redes", DataNascimento=new DateTime(1987,07,12), Nacionalidade="Portugal", Altura=1.74, Peso=78.7,  Fotografia="MarceloBento.jpg", EquipaPK=14 },
               new Jogadores {ID=142, Nome="Ricardo Costa", Posicao="Guarda Redes", DataNascimento=new DateTime(1983,02,20), Nacionalidade="Portugal", Altura=1.76, Peso=87.8,  Fotografia="RicardoCosta.jpg", EquipaPK=14 },
               new Jogadores {ID=143, Nome="António Pereira", Posicao="Defesa/Médio", DataNascimento=new DateTime(1989,09,01), Nacionalidade="Portugal", Altura=1.76, Peso=81.1,  Fotografia="AntonioPereira.jpg", EquipaPK=14 },
               new Jogadores {ID=144, Nome="Márcio Rosa", Posicao="Defesa/Médio", DataNascimento=new DateTime(1991,07,31), Nacionalidade="Portugal", Altura=1.81, Peso=80.9,  Fotografia="MarcioRosa.jpg", EquipaPK=14 },
               new Jogadores {ID=145, Nome="Filipe Bernardino", Posicao="Defesa/Médio", DataNascimento=new DateTime(1989,08,28), Nacionalidade="Portugal", Altura=1.77, Peso=76.7,  Fotografia="FilipeBernardino.jpg", EquipaPK=14 },
               new Jogadores {ID=146, Nome="Rúben Silva", Posicao="Defesa/Médio", DataNascimento=new DateTime(1987,03,05), Nacionalidade="Portugal", Altura=1.79, Peso=82.1,  Fotografia="RubenSilva.jpg", EquipaPK=14 },
               new Jogadores {ID=147, Nome="José Gonçalves", Posicao="Avançado", DataNascimento=new DateTime(1991,05,04), Nacionalidade="Portugal", Altura=1.83, Peso=72.0,  Fotografia="JoseGonsalves.jpg", EquipaPK=14 },
               new Jogadores {ID=148, Nome="Hugo dos Santos", Posicao="Avançado", DataNascimento=new DateTime(1987,10,29), Nacionalidade="Portugal", Altura=1.69,Peso=64.8,  Fotografia="HugoSantos.jpg", EquipaPK=14 },
               new Jogadores {ID=149, Nome="João Pereira", Posicao="Avançado", DataNascimento=new DateTime(1991,09,27), Nacionalidade="Portugal", Altura=1.81,Peso=82.6,  Fotografia="JoaoPereira.jpg", EquipaPK=14 },
               new Jogadores {ID=150, Nome="José Bernardo", Posicao="Avançado", DataNascimento=new DateTime(1997,01,25), Nacionalidade="Portugal", Altura=1.78,Peso=77.3,  Fotografia="JoseBernardo.jpg", EquipaPK=14 },

               };
            jogadores.ForEach(jj => context.Jogadores.AddOrUpdate(j => j.ID, jj));
            context.SaveChanges();

            //***************************************************************************************************************
            // adiciona TORNEIOS
            var torneios = new List<Torneios> {
                new Torneios {ID=1, Nome=" Campeonato Nacional", ListaDeEquipas = new List<Equipas>{equipas[0], equipas[1], equipas[2], equipas[3], equipas[4], equipas[5], equipas[6], equipas[7], equipas[8], equipas[9], equipas[10], equipas[11], equipas[12], equipas[13]}},
                new Torneios {ID=2, Nome=" Taça de Portugal", ListaDeEquipas = new List<Equipas>{equipas[0],equipas[1],equipas[2], equipas[3], equipas[4], equipas[5], equipas[6], equipas[7], equipas[8], equipas[9], equipas[10], equipas[11], equipas[12], equipas[13]}},
                new Torneios {ID=3, Nome=" Supertaça António Livramento", ListaDeEquipas = new List<Equipas>{equipas[2],equipas[6]}}

            };
            torneios.ForEach(tt => context.Torneios.AddOrUpdate(t => t.ID, tt));
            context.SaveChanges();

            //***************************************************************************************************************
            //adiciona UTILIZADORES
            var utilizadores = new List<Utilizadores>{
                new Utilizadores {ID=1, Username="jcarloslopes3@hotmail.com", NomeCompleto="José Carlos Lopes", Email="jcarloslopes@hotmail.com", ContactoTelefonico="910352191", DataNascimento= new DateTime(1980,03,25)},
                new Utilizadores {ID=2, Username="ananunesrib9@gmail.com", NomeCompleto="Ana Nunes Ribeiro", Email="ananunesrib@gmail.com", ContactoTelefonico="967892213", DataNascimento= new DateTime(1986,09,17)},
                new Utilizadores {ID=3, Username="ralvesferreira3@hotmail.com", NomeCompleto="Ricardo Alves Ferreira", Email="ralvesferreira3@hotmail.com", ContactoTelefonico="912374562", DataNascimento= new DateTime(1979,10,09)},
            };
            utilizadores.ForEach(uu => context.Utilizadores.AddOrUpdate(u => u.ID, uu));
            context.SaveChanges();

            //*************************************************************************************************************
            // adiciona NOTICIAS
            var noticias = new List<Noticias>{
                new Noticias {ID=1, Titulo="FC Porto x Sporting com lotação esgotada", Conteudo="Menos de duas horas. Foi o tempo que bastou para os bilhetes da meia final da Liga Europeia, entre FC Porto e Sporting, esgotarem no Dragão Caixa." +
                "Segundo anunciou o FC Porto, os ingressos que foram colocados à venda na manhã desta quarta-feira estão já completamente esgotados, para aquele que será o primeiro jogo da final four da Liga Europeia que o Dragão Caixa organizará." +
                "O jogo entre FC Porto e Sporting está agendado para as 12h30, enquanto que três horas depois há lugar para o Barcelona x Reus, jogo para o qual ainda existem bilhetes disponíveis. Para domingo, às 12h30, está agendada a final da competição.", Data=new DateTime(2018,05,09), Fotografia="Noticia1.jpg", UtilizadorPK=1, ListaDeEquipas = new List<Equipas>{equipas[1], equipas[2]}},
                new Noticias {ID=2, Titulo="Benfica cola-se ao FC Porto na liderança", Conteudo="Num final de semana marcado pelo empate do Sporting em Barcelos (2x2), o Benfica terminou com a jornada 22 com um triunfo, em casa, por 5x2, perante a Oliveirense, colando-se ao FC Porto na liderança do campeonato." +
                "A vitória começou a desenhar-se logo na primeira parte, com uma metade inicial demolidora dos encarnados. Um hattrick de João Rodrigues e um golo de Diogo Rafael levaram o Benfica a vencer por 4x0 para o intervalo. " +
                "Na segunda parte, a Oliveirense ainda encurtou a vantagem encarnada para 4x2, por Ricardo Barreiros e Nuno Araújo, aproveitando o desperdício encarnado, que falhara dois penáltis e um livre direto até então. Até final, destaque para o fechar de contas por Diogo Rafael." +
                "Na próxima jornada, o Benfica continua com o calendário difícil: o jogo é no Dragão Caixa, daqui a duas semanas. Já a Oliveirense recebe o Turquel.", Data=new DateTime(2018,05,07), Fotografia="Noticia2.jpg",  UtilizadorPK=1, ListaDeEquipas = new List<Equipas>{equipas[0], equipas[2]}},
                new Noticias {ID=3, Titulo="Sporting escorrega em Barcelos e complica contas do título", Conteudo="O Sporting não passou no Municipal de Barcelos! Num dos jogos grandes da 22ª jornada da 1ª Divisão, os leões não foram além de um empate (2x2) frente ao Óquei Clube de Barcelos, podendo terminar a ronda na terceira posição." +
                "Os visitantes entraram melhor no jogo, chegando ao primeiro golo logo aos quatro minutos, por Vítor Hugo. O conjunto da casa reagiu e conseguiu a igualdade por Juanjo, aos 11´." +
                "No segundo tempo, o Sporting voltou a entrar melhor, voltando a conseguir mexer no marcador, com o segundo tento de Vítor Hugo. A quatro minutos do final, o conjunto orientado por Paulo Pereira restabeleceu o empate por Marinho, com a divisão de pontos a verificar-se no final.", Data=new DateTime(2018,05,06), Fotografia="Noticia3.jpg",  UtilizadorPK=2, ListaDeEquipas = new List<Equipas>{equipas[1], equipas[7]}},
                new Noticias {ID=4, Titulo="Xanoca fica sem jogar 2 meses mas castigo era de 1 ano", Conteudo="Xanoca, do SC Tomar, não voltará a jogar esta temporada devido a um castigo aplicado pelo Conselho de Disciplina da Federação de Patinagem de Portugal. " +
             "Mas o caso é insólito. O castigo de um ano de suspensão foi dado como iniciado a 30 de junho de 2017, mas só esta sexta-feira é que foi dado a conhecer, o que significa que Xanoca esteve a jogar durante o periodo em que era suposto estar castigado." +
             "Desta forma, uma vez que o castigo apenas foi anunciado esta sexta-feira, Xanoca vai cumprir apenas cerca de dois meses de suspensão, falhando as cinco jornadas finais do campeonato, mais a final-four da Taça de Portugal, na qual o SC Tomar tem encontro marcado com a AD Valongo nas meias-finais." +
             "O caso remonta à temporada passada, em que Xanoca é acusado de em três momentos distintos – quarto trimestre de 2016 e primeiro e terceiro de trimestres de 2017 - não ter comunicado a sua localização para um eventual controlo antidopagem, algo obrigatório para os jogadores que estão em via de poderem representar as seleções nacionais." +
             "No entanto, Xanoca terá enviado a informação acerca da sua localização para o Conselho Nacional Antidopagem mas em ficheiros não aceites pela autoridade de antidopagem, o que na prática levou à imposição do castigo de um ano sem competição devido a «negligência». Uma suspensão proposta pelo Conselho Nacional Antidopagem e acatada pelo Conselho de Disciplina da Federação de Patinagem de Portugal, embora a federação tenha proposto apenas uma advertência ao jogador." +
             "O caso remonta ainda ao período em que Xanoca representava o HC Turquel, tendo assinado pelo SC Tomar no início da presente temporada, na qual acabou por disputar 28 jogos e apontar cinco golos. Entretanto, o jogador tem já acordo para continuar a representar os nabantinos na época quem", Data=new DateTime(2018,05,05), Fotografia="Noticia4.jpg", UtilizadorPK=3, ListaDeEquipas = new List<Equipas>{equipas[6]}},
                new Noticias {ID=5, Titulo="Guilherme Silva: «Lutaremos pelo 5.º lugar até final»", Conteudo="São 32 os pontos que separam a AD Valongo do Grândola, quinto e último classificados, respetivamente. As duas equipas medem forças este sábado, em partida referente à 22.ª jornada do campeonato, e Guilherme Silva, hoquista dos valonguenses, aponta à conquista dos três pontos para o objetivo de segurar o quinto lugar ficar mais perto." +
                "«Em casa somos uma equipa muito forte, estamos na reta final do campeonato e queremos acabá-lo da melhor maneira», afirmou Guilherme Silva. " +
                "«Pensamos jogo a jogo e em conquistar os três pontos. O nosso objetivo é o quinto lugar e vamos lutar por ele até final», acrescentou o avançado valonguense, que garantiu que esta forma de pensar vai ser posta em prática diante do Grândola.«O Grândola é uma equipa que está a lutar pela manutenção e sabemos que vai dar tudo para a conseguir. No jogo da primeira volta criou-nos dificuldades, mas estamos a preparar-nos bem para conquistar os três pontos»." +
                "Autor de nove golos esta época, sete no campeonato e dois na Taça de Portugal, Guilherme Silva, que cumpre a segunda temporada na AD Valongo, está satisfeito com o trabalho que a equipa tem vindo a fazer e diz sentir-se a evoluir a nível pessoal." +
                "«Sinto que estou a crescer de dia para dia. Os métodos de trabalho aqui são muito bons, o que faz com que os jogadores evoluam muito. A nível de campeonato sinto que estou a fazer uma boa época, tenho ajudado sempre a equipa e vou continuar a fazê-lo até ao final», finalizou o jogador que tem também como objetivo tentar conquistar a Taça de Portugal, uma vez que a AD Valongo ainda está em prova, tendo encontro marcado com o SC Tomar nas meias-finais.", Data=new DateTime(2018,05,18), Fotografia="Noticia5.jpg", UtilizadorPK=2, ListaDeEquipas = new List<Equipas>{equipas[10]}},
            };
            noticias.ForEach(nn => context.Noticias.AddOrUpdate(n => n.ID, nn));
            context.SaveChanges();

            


        }
    }
}

