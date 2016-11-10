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

            foreach (var method in methods)
            {
                var modifier = AccessModifier.AccessPrivate;

                if (method.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword)))
                {
                    modifier = AccessModifier.AccessPublic;
                }
                else if (method.Modifiers.Any(m => m.IsKind(SyntaxKind.ProtectedKeyword)))
                {
                    modifier = AccessModifier.AccessProtected;
                }

                int nesting = method.DescendantNodes().OfType<BlockSyntax>().Count();

                list.Add(new FunctionInfo() { Name = method.Identifier.ToString(), Modifier = modifier, NestingLevel = nesting });
            }
            //    var activeSemanticModel = document.GetSemanticModelAsync().Result;

            return list;
        }
    }
}
