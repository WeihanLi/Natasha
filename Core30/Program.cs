using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;
using Natasha;
using System;

namespace Core30
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *   在此之前，你需要右键，选择工程文件，在你的.csproj里面 
             *   
             *   写上这样一句浪漫的话： 
             *   
             *      <PreserveCompilationContext>true</PreserveCompilationContext>
             */


//            string text = @"namespace HelloWorld
//{
//    public class Test
//    {
//        public Test(){
//            Name=""111"";
//        }

//        public string Name;
//        public int Age{get;set;}
//    }
//}";
//            //根据脚本创建动态类
//            Type type = ClassBuilder.GetType(text);
//            //创建动态类实例代理
//            DynamicOperator instance = type;

//            if (instance["Name"].StringValue == "111")
//            {
//                //调用动态委托赋值
//                instance["Name"].StringValue = "222";
//            }
//            //调用动态类
//            Console.WriteLine(instance["Name"].StringValue);

//            TestB b = new TestB();
//            b.Name = "abc";
//            var result = CloneOperator.Clone(b);


//            //创建动态类实例代理
//            DynamicOperator<TestB> instance2 = new DynamicOperator<TestB>();

//            if (instance2["Name"].StringValue == "111")
//            {
//                //调用动态委托赋值
//                instance2["Name"].StringValue = "222";
//            }
//            //调用动态类
//            Console.WriteLine(instance2["Name"].StringValue);



            var source =
           @"class A
{private struct S { 
}
}";

            SyntaxTree? tree = CSharpSyntaxTree.ParseText(source);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();


            AdhocWorkspace adhoc = new AdhocWorkspace();
            adhoc.AddSolution(SolutionInfo.Create(SolutionId.CreateNewId("test"),VersionStamp.Default));
            
            foreach (var item in adhoc.Services.SupportedLanguages)
            {
                Console.WriteLine(item);
            }

            var temp = Formatter.Format(root, adhoc);
            Console.WriteLine(temp.ToString());
            Console.ReadKey();


            Console.ReadKey();

        }
    }
    public class TestB
    {
        public TestB()
        {
            Name = "111";
        }
        public string Name { get; set; }
        public int Age;
    }
}
