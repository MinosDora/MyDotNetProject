using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Runtime.Serialization;

namespace MyDotNetProject
{
    class ExceptionTests
    {
        public static void Test1()
        {
            try
            {
                TestFunc1();
            }
            catch (Exception)
            {
                Console.WriteLine("Main Catch.");
            }
            finally
            {
                Console.WriteLine("Main Finally.");
            }

            Console.WriteLine("Main Done.");

            ThreadPool.QueueUserWorkItem((state) =>
            {
                TestFunc1();
            });

            Console.Read();
        }

        private static void TestFunc1()
        {
            try
            {
                try
                {
                    throw new FileNotFoundException();
                }
                finally
                {
                    Console.WriteLine("In MyFunc Finally.");

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("MyFunc FileNotFoundException Catch.");
                throw;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("MyFunc DirectoryNotFoundException Catch.");
                throw;
            }
            catch (IOException)
            {
                Console.WriteLine("MyFunc IOException Catch.");
                throw;
            }
            catch (Exception)
            {

            }
            finally
            {
                Console.WriteLine("My Func Finally.");
            }

            Console.WriteLine("My Func Done.");
        }
    }
}