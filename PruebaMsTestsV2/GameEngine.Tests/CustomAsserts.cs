using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GameEngine.Tests
{
    public static class CustomAsserts
    {
        public static void IsInRange(this Assert assert, int actual, int expectedMinimumValue, int expectedMaximunValue)
        {
            if (actual < expectedMinimumValue || actual > expectedMaximunValue)
            {
                throw new AssertFailedException($"{actual} no esta en el rango {expectedMinimumValue} - {expectedMaximunValue}");
            }
        }

        public static void AllItemsNotNullOrWhitespaces(this CollectionAssert collectionAssert, ICollection<string> collection)
        {
            foreach (var item in collection)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    throw new AssertFailedException($"Uno o mas items son null o tienen espacios en blanco");
                }
            }
        }

        public static void AllItemsSatisfy<T>(this CollectionAssert collectionAssert, ICollection<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    throw new AssertFailedException($"Todos los elementos no cumplen el predicado");
                }
            }
        }

        /// <summary>
        /// Si un item pasa la condicion da true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionAssert"></param>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        public static void AtLeastOneItemSatisfy<T>(this CollectionAssert collectionAssert, ICollection<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return;
                }
            }
            throw new AssertFailedException($"el elemento no cumple el predicado");
        }

        /// <summary>
        /// Ejecuta cualquier Asset en una collecion
        /// </summary>
        /// <param name="collection">Collecion</param>
        /// <param name="assert">Assert</param>
        public static void All<T>(this CollectionAssert collectionAssert, ICollection<T> collection, Action<T> assert)
        {
            foreach (var item in collection)
            {
                assert(item);
            }
        }

        /// <summary>
        /// Creando Metodo para StringAssert
        /// </summary>
        /// <param name="stringAssert"></param>
        /// <param name="actual"></param>
        public static void NotNullOrWhitespace(this StringAssert stringAssert, string actual)
        {
            if (string.IsNullOrWhiteSpace(actual))
            {
                throw new AssertFailedException($"Valor es null o espacios en blancos");
            }
        }
    }
}