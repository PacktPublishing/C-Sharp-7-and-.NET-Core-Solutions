﻿using System.Linq;
using static System.Console;
using static System.Math;
using System;
using System.Collections.Generic;
using System.Text;


namespace cookbook
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Chapter 1 - Tuples
            /*
            int[] scores = { 17, 46, 39, 62, 81, 79, 52, 24 };
            //int[] scores = { 17, 46, 39, 62, 81, 79, 52, 24, 49 }; // The gotcha
            Test t = new Test();
            //var (average, studentCount) = t.GetAverageAndCount(scores);
            int threshold = 40;
            var (average, studentCount, belowAverage) = t.GetAverageAndCount(scores, threshold);

            //WriteLine($"Average was {average} across {studentCount} students");
            //WriteLine($"Average was {average} across {studentCount} students. {(average < threshold ? " Class score below average." : " Class score above average.")}");
            WriteLine($"Average was {Round(average,2)} across {studentCount} students. {(average < threshold ? " Class score below average." : " Class score above average.")}");
            */
            #endregion

            #region Section 1 - Pattern Matching
            /*
            Test t = new Test();

            Student student = new Student();
            student.Name = "Dirk";
            student.LastName = "Strauss";
            student.CourseCodes = new List<int> { 203, 202, 101 };

            t.OutputInformation(student);

            Professor prof = new Professor();
            prof.Name = "Reinhardt";
            prof.LastName = "Botha";
            prof.TeachesSubjects = new List<string> { "Mobile Development", "Cryptography" };

            t.OutputInformation(prof);
            */
            #endregion

            #region Section 1 - Out variables
            //string sValue = "500";

            #region Old out variable implementation
            //int intVal;
            //if (int.TryParse(sValue, out intVal))
            //{
            //    WriteLine($"{intVal} is a valid integer");
            //    // Do something with intVal
            //} 
            #endregion

            #region New out variable implementation
            //if (int.TryParse(sValue, out int intVal))
            //{
            //    WriteLine($"{intVal} is a valid integer");
            //    // Do something with intVal
            //} 

            //if (int.TryParse(sValue, out var intVal))
            //{
            //    WriteLine($"{intVal} is a valid integer");
            //    // Do something with intVal
            //}

            //var (original, intVal, isInteger) = sValue.ToInt();
            //if (isInteger)
            //{
            //    WriteLine($"{original} is a valid integer");
            //    // Do something with intVal
            //}
            #endregion
            #endregion

            #region Section 1 - Deconstructors
            //Student student = new Student();
            ////Student student = new Student("S20323742");
            //student.Name = "Dirk";
            //student.LastName = "Strauss";

            //var (FirstName, Surname) = student;
            //WriteLine($"The student name is {FirstName} {Surname}"); 
            #endregion

            #region Section 1 - Local Functions
            //Test t = new Test();
            //Building bldng = t.GetShopfloorSpace(200, 35, 100);
            //WriteLine($"The total space for shops is {bldng.TotalShopFloorSpace} square meters"); 
            #endregion

            #region Section 1 - Literal Improvements
            //var oldNum = 342057239127493;
            //var newNum = 342_057_239_127_493;
            //WriteLine($"oldNum = {oldNum} and newNum = {newNum}"); 
            #endregion

            #region Section 1 - Throw Exceptions
            //try
            //{
            //    Test t = new Test();
            //    int nameLength = t.GetNameLength("", "");
            //}
            //catch (Exception ex)
            //{

            //    WriteLine(ex.Message);
            //} 
            #endregion

            #region Section 1 - Ref returns and locals
            //int a = 10;
            //int b = 20;
            //Test t = new Test();
            //int val = ch1.GetLargest(a, b);
            //val += 25;

            //WriteLine($"val = {val} a = {a} b = {b} ");

            //ref int refVal = ref ch1.GetLargest(ref a, ref b);
            //refVal += 25;

            //WriteLine($"refVal = {refVal} a = {a} b = {b} ");

            #region View Memory Addresses
            /*
                 * Go to the Properties of the current project
                 * In the Build tab, check the Allow unsafe code option and save the properties
                 * Uncomment the following code and run the Console Application
                unsafe
                {
                    IntPtr a_var_memoryAddress = (IntPtr)(&a);
                    IntPtr b_var_memoryAddress = (IntPtr)(&b);
                    IntPtr val_var_memoryAddress = (IntPtr)(&val);

                    fixed (int* refVal_var = &refVal)
                    {
                        IntPtr refVal_var_memoryAddress = (IntPtr)(refVal_var);
                        WriteLine($"The memory address of a is {a_var_memoryAddress}");
                        WriteLine($"The memory address of b is {b_var_memoryAddress}");
                        WriteLine($"The memory address of val is {val_var_memoryAddress}");
                        WriteLine($"The memory address of refVal is {refVal_var_memoryAddress}");
                    }
                }
                */
            #endregion
            #endregion


            WindowHeight = 18;
            WindowWidth = 62;
            
            ReadLine();
        }
                
    }

    public class Test
    {
        #region Tuples
        public (int average, int studentCount) GetAverageAndCount(int[] scores)
        {
            var returnTuple = (ave: 0, sCount: 0);

            returnTuple = (scores.Sum() / scores.Count(), scores.Count());

            return returnTuple;
        }

        public (double average, int studentCount, bool belowAverage) GetAverageAndCount(int[] scores, int threshold)
        {
            var returnTuple = (ave: 0D, sCount: 0, subAve: true);

            returnTuple = ((double)scores.Sum() / scores.Count(), scores.Count(), returnTuple.ave.CheckIfBelowAverage(threshold));

            return returnTuple;
        }
        #endregion
        
        #region Pattern Matching
        public void OutputInformation(object person)
        {
            #region Old Method
            /*
                if (person is Student)
                {
                    Student student = (Student)person;
                    WriteLine($"Student {student.Name} {student.LastName} is enrolled for courses {String.Join<int>(", ", student.CourseCodes)}");
                }
                if (person is Professor)
                {
                    Professor prof = (Professor)person;
                    WriteLine($"Professor {prof.Name} {prof.LastName} teaches {String.Join<string>(",", prof.TeachesSubjects)}");
                }
                */
            #endregion

            #region Type Pattern and Constant matching
            /*
                if (person is null)
                {
                    WriteLine($"Object {nameof(person)} is null");
                }
                if (person is Student student)
                {
                    WriteLine($"Student {student.Name} {student.LastName} is enrolled for courses {String.Join<int>(", ", student.CourseCodes)}");
                }
                if (person is Professor prof)
                {
                    WriteLine($"Professor {prof.Name} {prof.LastName} teaches {String.Join<string>(",", prof.TeachesSubjects)}");
                }
                */
            #endregion

            #region Switch statements and Pattern Matching
            switch (person)
            {
                case Student student when (student.CourseCodes.Contains(203)):
                    WriteLine($"Student {student.Name} {student.LastName} is enrolled for course 203.");
                    break;
                case Student student:
                    WriteLine($"Student {student.Name} {student.LastName} is enrolled for courses {String.Join<int>(", ", student.CourseCodes)}");
                    break;
                case Professor prof:
                    WriteLine($"Professor {prof.Name} {prof.LastName} teaches {String.Join<string>(",", prof.TeachesSubjects)}");
                    break;
                case null:
                    WriteLine($"Object {nameof(person)} is null");
                    break;
                default:
                    WriteLine("Unknown object detected");
                    break;
            }
            #endregion
        }
        #endregion

        #region Local Functions
        public Building GetShopfloorSpace(int floorCommonArea, int buildingWidth, int buildingLength)
        {
            Building building = new Building();

            building.TotalShopFloorSpace = CalculateShopFloorSpace(floorCommonArea, buildingWidth, buildingLength);

            int CalculateShopFloorSpace(int common, int width, int length)
            {
                return (width * length) - common;
            }

            //building.TotalShopFloorSpace = CalculateShopFloorSpace(10, 9, 17);

            return building;
        }
        #endregion

        #region Throw Exceptions
        public int GetNameLength(string firstName, string lastName)
        {
            return (firstName.Length + lastName.Length) > 0 ? firstName.Length + lastName.Length : throw new Exception("First name and last name is empty");
        }
        #endregion

        #region Ref returns and locals
        public ref int GetLargest(ref int valueA, ref int valueB)
        {
            if (valueA > valueB)
                return ref valueA;
            else
                return ref valueB;
        }

        public int GetLargest(int valueA, int valueB)
        {
            if (valueA > valueB)
                return valueA;
            else
                return valueB;
        } 
        #endregion                
    }


    #region Student Class
    #region Basic Student Class
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<int> CourseCodes { get; set; }

        #region Deconstructor added for recipe on Deconstructors
        //public void Deconstruct(out string name, out string lastName)
        //{
        //    name = Name;
        //    lastName = LastName;
        //}
        #endregion
    } 
    #endregion

    #region Expanded Implementation of Student Class
    //public class Student
    //{
    //    public Student(string studentNumber)
    //    {
    //        (Name, LastName) = GetStudentDetails(studentNumber);
    //    }
    //    public string Name { get; private set; }
    //    public string LastName { get; private set; }
    //    public List<int> CourseCodes { get; private set; }

    //    public void Deconstruct(out string name, out string lastName)
    //    {
    //        name = Name;
    //        lastName = LastName;
    //    }

    //    private (string name, string surname) GetStudentDetails(string studentNumber)
    //    {
    //        var detail = (n: "Dirk", s: "Strauss");
    //        // Do something with student number to return the student details
    //        return detail;
    //    }
    //} 
    #endregion
    #endregion

    #region Professor Class
    public class Professor
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> TeachesSubjects { get; set; }
    }
    #endregion

    #region Building Class
    public class Building
    {
        public int TotalShopFloorSpace { get; set; }
    }
    #endregion

    #region Expression-Bodied Members
    //public class SomeClass
    //{
    //    private int _initialValue;

    //    public int InitialValue
    //    {
    //        get
    //        {
    //            return _initialValue;
    //        }

    //        set
    //        {
    //            _initialValue = value;
    //        }
    //    }

    //    public SomeClass(int initialValue)
    //    {
    //        InitialValue = initialValue;
    //    }

    //    ~SomeClass()
    //    {
    //        WriteLine("Release unmanaged code");
    //    }
    //}

    public class SomeClass
    {
        private int _initialValue;

        public int InitialValue
        {
            get => _initialValue;
            set => _initialValue = value;
        }

        public SomeClass(int initialValue) => InitialValue = initialValue;

        ~SomeClass() => WriteLine("Release unmanaged code");
    } 
    #endregion

    #region Extension Methods Class
    public static class ExtensionMethods
    {
        public static bool CheckIfBelowAverage(this double classAverage, int threshold)
        {
            if (classAverage < threshold)
            {
                // Notify head of department
                return true;
            }
            else
                return false;
        }
        
        public static (string originalValue, int integerValue, bool isInteger) ToInt(this string stringValue)
        {
            var t = (original: stringValue, toIntegerValue: 0, isInt: false);
            if (int.TryParse(stringValue, out var iValue)) { t.toIntegerValue = iValue; t.isInt = true; }
            return t;
        }

        public static void Deconstruct(this Student student, out string firstItem, out string secondItem)
        {
            firstItem = student.Name;
            secondItem = student.LastName;
        }
    } 
    #endregion
}








