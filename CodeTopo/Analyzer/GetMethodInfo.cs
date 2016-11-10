using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTopo.Analyzer
{
    public class GetMethodInfo
    {
        public List<FunctionInfo> Get(SyntaxTree activeSyntaxTree)
        {
            var methods = activeSyntaxTree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();

            var list = new List<FunctionInfo>();

            foreach (var bar in methods)
            {
                var modifier = AccessModifier.AccessPrivate;

                if (bar.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword)))
                {
                    modifier = AccessModifier.AccessPublic;
                }
                else if (bar.Modifiers.Any(m => m.IsKind(SyntaxKind.ProtectedKeyword)))
                {
                    modifier = AccessModifier.AccessProtected;
                }

                list.Add(new FunctionInfo() { Name = bar.Identifier.ToString(), Modifier = modifier });
            }
            //    var activeSemanticModel = document.GetSemanticModelAsync().Result;

            return list;
        }
    }
}
