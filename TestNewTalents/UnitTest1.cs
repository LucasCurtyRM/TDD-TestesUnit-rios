using System;
using Xunit;
using NewTalents.Models;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System.Reflection.Emit;
namespace TestNewTalents
{
    public class UnitTest1
    {

        public Calculadora ConstruirClasse(){
            string data = "02/02/2020";
            Calculadora calc = new Calculadora(data);
            return calc;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        public void TestSomar(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruirClasse();
            
            int resultadoCalculadora  = calc.Somar(num1, num2);
            
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 3, 6)]
        public void TestMultiplicar(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruirClasse();
            
            int resultadoCalculadora  = calc.Multiplicar(num1, num2);
            
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(4, 2, 2)]
        public void TestSubtrair(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruirClasse();
            
            int resultadoCalculadora  = calc.Subtrair(num1, num2);
            
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(20, 2, 10)]
        public void TestDividir(int num1, int num2, int resultado)
        {
            Calculadora calc = ConstruirClasse();
            
            int resultadoCalculadora  = calc.Dividir(num1, num2);
            
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDividirPorZero(){
            Calculadora calc = ConstruirClasse();
            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(3, 0)
                );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = ConstruirClasse();

            calc.Somar(1, 2);
            calc.Somar(4, 3);
            calc.Somar(2, 9);
            
            var lista = calc.Historico();
            Assert.NotEmpty(calc.Historico());
        }
    }
}
