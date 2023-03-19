using System.Collections.Generic;
using Xunit;

namespace StringHelper.Test
{
    public class MatcherShould
    {

        #region BuscarMejor

        [Fact]
        public void BuscarMejorEligeLaDePalabraExacta()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            var lineas = new List<string>() { "palabrapalabra", "palabra", "palabrax", "pal" };
            //Act
            var mejorPalabra = Matcher.BuscarMejor(cadenaBuscada, lineas);
            //Assert
            Assert.Equal("palabra", mejorPalabra);
        }

        [Fact]
        public void BuscarMejorEligeLaDeMejorPuntaje()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            var lineas = new List<string>() { "palabrapalabra", "palabrax", "pal" };
            //Act
            var mejorPalabra = Matcher.BuscarMejor(cadenaBuscada, lineas);
            //Assert
            Assert.Equal("palabrax", mejorPalabra);
        }

        [Fact]
        public void BuscarMejorEligeLaMasParecida1()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            var lineas = new List<string>() { "palabrapalabra x", "pal x", "palabra palabra x", "palabra x" };
            //Act
            var mejorPalabra = Matcher.BuscarMejor(cadenaBuscada, lineas);
            //Assert
            Assert.Equal("palabra x", mejorPalabra);
        }

        [Fact]
        public void BuscarMejorEligeLaMasParecida2()
        {
            //Arrange
            var cadenaBuscada = "palabra palabra";
            var lineas = new List<string>() { "palabrapalabra x", "pal x", "palabra x", "palabra palabra x" };
            //Act
            var mejorPalabra = Matcher.BuscarMejor(cadenaBuscada, lineas);
            //Assert
            Assert.Equal("palabra palabra x", mejorPalabra);
        }

        #endregion

        #region BusquedaExacta

        [Fact]
        public void BusquedaExactaEligePalabraExacta()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            var lineas = new List<string>() { "xpalabra", "palabra", "palabrax" };
            //Act
            var mejorPalabra = Matcher.BusquedaExacta(cadenaBuscada, lineas);
            //Assert
            Assert.Equal("palabra", mejorPalabra);
        }

        [Fact]
        public void BusquedaExactaEligePalabraNormalizada()
        {
            //Arrange
            var cadenaBuscada = "Palabra";
            var lineas = new List<string>() { "xpalabra", "palabra", "palabrax" };
            //Act
            var mejorPalabra = Matcher.BusquedaExacta(cadenaBuscada, lineas);
            //Assert
            Assert.Equal("palabra", mejorPalabra);
        }

        [Fact]
        public void BusquedaExactaDevuelveNull()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            var lineas = new List<string>() { "xpalabra", "palabrax" };
            //Act
            var mejorPalabra = Matcher.BusquedaExacta(cadenaBuscada, lineas);
            //Assert
            Assert.Null(mejorPalabra);
        }

        #endregion

        #region BuscarPorPuntaje


        [Fact]
        public void BuscarPorPuntajeEligePalabraExacta()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            var lineas = new List<string>() { "pala", "palabrapalabra", "palabra" };
            //Act
            var mejorPalabra = Matcher.BuscarPorPuntaje(cadenaBuscada, lineas);
            //Assert
            Assert.Equal("palabra", mejorPalabra);
        }

        #endregion

        #region MaxPuntaje

        [Fact]
        public void MaxPuntajeDeNullEs0()
        {
            //Arrange
            string? cadena = null;
            //Act
            double puntaje = Matcher.MaxPuntaje(cadena);
            //Assert
            Assert.Equal(0, puntaje);
        }

        [Fact]
        public void MaxPuntajeDeEmptyEs0()
        {
            //Arrange
            string? cadena = string.Empty;
            //Act
            double puntaje = Matcher.MaxPuntaje(cadena);
            //Assert
            Assert.Equal(0, puntaje);
        }

        [Fact]
        public void MaxPuntajeDeUshuaiaEs28()
        {
            //Arrange
            string? cadena = "Ushuaia";
            //Act
            double puntaje = Matcher.MaxPuntaje(cadena);
            //Assert
            Assert.Equal(28, puntaje);
        }

        #endregion

        #region Normalizar

        [Fact]
        public void NormalizarConEnie()
        {
            //Arrange
            var cadena = "La ñata";
            //Act
            var cadenaNormalizada = Matcher.Normalizar(cadena);
            //Assert
            Assert.Equal("LA ATA", cadenaNormalizada);
        }

        [Fact]
        public void NormalizarConTilde()
        {
            //Arrange
            var cadena = "Asunción";
            //Act
            var cadenaNormalizada = Matcher.Normalizar(cadena);
            //Assert
            Assert.Equal("ASUNCIN", cadenaNormalizada);
        }

        [Fact]
        public void NormalizarConPunto()
        {
            //Arrange
            var cadena = "Bs.As.";
            //Act
            var cadenaNormalizada = Matcher.Normalizar(cadena);
            //Assert
            Assert.Equal("BSAS", cadenaNormalizada);
        }

        [Fact]
        public void NormalizarConInterrogacion()
        {
            //Arrange
            var cadena = "Tucum?n";
            //Act
            var cadenaNormalizada = Matcher.Normalizar(cadena);
            //Assert
            Assert.Equal("TUCUMN", cadenaNormalizada);
        }

        #endregion

        #region ObtenerPuntaje

        [Fact]
        public void ObtenerPuntajeDePuanEnPuanEs10()
        {
            //Arrange
            string cadena = "puan";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(10, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDePuaxEnPuanEs6()
        {
            //Arrange
            string cadena = "puax";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(6, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDePuxnEnPuanEs4()
        {
            //Arrange
            string cadena = "puxn";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(4, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDePxanEnPuanEs4()
        {
            //Arrange
            string cadena = "pxan";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(4, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDeXuanEnPuanEs6()
        {
            //Arrange
            string cadena = "xuan";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(6, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDePuxxEnPuanEs3()
        {
            //Arrange
            string cadena = "puxx";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(3, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDePxxnEnPuanEs2()
        {
            //Arrange
            string cadena = "pxxn";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(2, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDeXxanEnPuanEs3()
        {
            //Arrange
            string cadena = "xxan";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(3, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDePxxxEnPuanEs1()
        {
            //Arrange
            string cadena = "pxxx";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(1, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDeXxxnEnPuanEs1()
        {
            //Arrange
            string cadena = "xxxn";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(1, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDeXxxxEnPuanEs0()
        {
            //Arrange
            string cadena = "xxxx";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(0, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDeNullEnPuanEs0()
        {
            //Arrange
            string? cadena = null;
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(0, puntaje);
        }

        [Fact]
        public void ObtenerPuntajeDeEmptyEnPuanEs0()
        {
            //Arrange
            string cadena = string.Empty;
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerPuntaje(cadena, texto);
            //Assert
            Assert.Equal(0, puntaje);
        }

        #endregion

    }
}