using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewEnginePlus
{
    public class ViewEnginePlus //: IViewEngine
    {
        public static String viewCase;
        public static String folderCase;
        private static List<ViewEnginePlusCase> testCases = new List<ViewEnginePlusCase>();

        public static void AddViewRule(string stateName, Func<bool> testCase)
        {
            var engineCase = new ViewEnginePlusCase();
            engineCase.name = stateName;
            engineCase.caseFunction = testCase;

            testCases.Add(engineCase);
        }

        public static void AddFolderRule() { 
            
        }

        public static void TestViewCases()
        {
            //passedState = (bool)testCases[0].caseFunction.DynamicInvoke();

            foreach (ViewEnginePlusCase testCase in testCases)
            {
                if ((bool)testCase.caseFunction.DynamicInvoke())
                {
                    // it has passed so lets break out and set var

                    viewCase = testCase.name;
                    break;
                }
            }
        }


        private class ViewEnginePlusCase
        {
            public String name;
            public Delegate caseFunction;
        }
    }
    
}
