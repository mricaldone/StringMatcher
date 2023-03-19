using System.Collections.Generic;
using Xunit;

namespace StringHelper.Test
{
    public class MatcherShould
    {

        #region BuscarMejor

        [Fact]
        public void BuscarMejorDeListaNullDevuelveNull()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            //Act
            var mejorPalabra = Matcher.BuscarMejor(cadenaBuscada, null);
            //Assert
            Assert.Null(mejorPalabra);
        }

        [Fact]
        public void BuscarMejorDeListaVaciaDevuelveNull()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            //Act
            var mejorPalabra = Matcher.BuscarMejor(cadenaBuscada, new List<string>());
            //Assert
            Assert.Null(mejorPalabra);
        }

        [Fact]
        public void BuscarMejorDeListaDeUnElementoDevuelveEseElemento()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            var lineas = new List<string>() { "x" };
            //Act
            var mejorPalabra = Matcher.BuscarMejor(cadenaBuscada, lineas);
            //Assert
            Assert.Equal("x", mejorPalabra);
        }

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
        public void BusquedaExactaDeListaNullDevuelveNull()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            //Act
            var mejorPalabra = Matcher.BusquedaExacta(cadenaBuscada, null);
            //Assert
            Assert.Null(mejorPalabra);
        }

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

        #region BusquedaPorProbabilidad

        [Fact]
        public void BusquedaPorProbabilidadDeListaNullDevuelveNull()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            //Act
            var mejorPalabra = Matcher.BusquedaPorProbabilidad(cadenaBuscada, null);
            //Assert
            Assert.Null(mejorPalabra);
        }

        [Fact]
        public void BusquedaPorProbabilidadEligePalabraExacta()
        {
            //Arrange
            var cadenaBuscada = "palabra";
            var lineas = new List<string>() { "pala", "palabrapalabra", "palabra" };
            //Act
            var mejorPalabra = Matcher.BusquedaPorProbabilidad(cadenaBuscada, lineas);
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
            Assert.Equal(" LA ATA ", cadenaNormalizada);
        }

        [Fact]
        public void NormalizarConTilde()
        {
            //Arrange
            var cadena = "Asunción";
            //Act
            var cadenaNormalizada = Matcher.Normalizar(cadena);
            //Assert
            Assert.Equal(" ASUNCIN ", cadenaNormalizada);
        }

        [Fact]
        public void NormalizarConPunto()
        {
            //Arrange
            var cadena = "Bs.As.";
            //Act
            var cadenaNormalizada = Matcher.Normalizar(cadena);
            //Assert
            Assert.Equal(" BSAS ", cadenaNormalizada);
        }

        [Fact]
        public void NormalizarConInterrogacion()
        {
            //Arrange
            var cadena = "Tucum?n";
            //Act
            var cadenaNormalizada = Matcher.Normalizar(cadena);
            //Assert
            Assert.Equal(" TUCUMN ", cadenaNormalizada);
        }

        #endregion

        #region ObtenerProbabilidad

        [Fact]
        public void ObtenerProbabilidadDePuanEnPuanEs_1()
        {
            //Arrange
            string cadena = "puan";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(1, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDePuaxEnPuanEs_06()
        {
            //Arrange
            string cadena = "puax";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.6, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDePuxnEnPuanEs_04()
        {
            //Arrange
            string cadena = "puxn";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.4, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDePxanEnPuanEs_04()
        {
            //Arrange
            string cadena = "pxan";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.4, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDeXuanEnPuanEs_06()
        {
            //Arrange
            string cadena = "xuan";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.6, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDePuxxEnPuanEs_03()
        {
            //Arrange
            string cadena = "puxx";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.3, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDePxxnEnPuanEs_02()
        {
            //Arrange
            string cadena = "pxxn";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.2, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDeXxanEnPuanEs_03()
        {
            //Arrange
            string cadena = "xxan";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.3, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDePxxxEnPuanEs_01()
        {
            //Arrange
            string cadena = "pxxx";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.1, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDeXxxnEnPuanEs_01()
        {
            //Arrange
            string cadena = "xxxn";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0.1, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDeXxxxEnPuanEs_0()
        {
            //Arrange
            string cadena = "xxxx";
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDeNullEnPuanEs_0()
        {
            //Arrange
            string? cadena = null;
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0, puntaje);
        }

        [Fact]
        public void ObtenerProbabilidadDeEmptyEnPuanEs_0()
        {
            //Arrange
            string cadena = string.Empty;
            string texto = "puan";
            //Act
            var puntaje = Matcher.ObtenerProbabilidad(cadena, texto);
            //Assert
            Assert.Equal(0, puntaje);
        }

        #endregion

    }
}