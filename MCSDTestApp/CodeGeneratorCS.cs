using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;


namespace MCSDTestApp
{
    class CodeGeneratorCS
    {

        public static void Main()
        {
            CSharpCodeProvider cs = new CSharpCodeProvider();

            CodeGenerator cg = new CodeGenerator();
            using (StreamWriter sw=new StreamWriter("HelloWorld.cs",false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "      ");
                cs.GenerateCodeFromCompileUnit(cg.GetCompierUnit(), tw, new CodeGeneratorOptions());
                tw.Close();
            }
        }
    }

    class CodeGenerator
    {
       public CodeCompileUnit GetCompierUnit()
        {

            CodeCompileUnit cu = new CodeCompileUnit();
            CodeNamespace cn = new CodeNamespace("MyNameSpace");
            cn.Imports.Add(new CodeNamespaceImport("System"));

            CodeTypeDeclaration myclass = new CodeTypeDeclaration("MyClass");
            CodeEntryPointMethod method = new CodeEntryPointMethod();
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Console"), "WriteLine", new CodePrimitiveExpression("Hello World"));

            cu.Namespaces.Add(cn);
            cn.Types.Add(myclass);
            myclass.Members.Add(method);
            method.Statements.Add(cs1);
            return cu;
        }

    }
}
