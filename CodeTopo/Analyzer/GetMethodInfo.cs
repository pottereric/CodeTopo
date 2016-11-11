using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

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
                var funcInfo = new FunctionInfo() { Name = method.Identifier.ToString() };
                var modifier = AccessModifier.AccessPrivate;

                if (method.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword)))
                {
                    modifier = AccessModifier.AccessPublic;
                }
                else if (method.Modifiers.Any(m => m.IsKind(SyntaxKind.ProtectedKeyword)))
                {
                    modifier = AccessModifier.AccessProtected;
                }
                funcInfo.Modifier = modifier;
                funcInfo.NestingLevel = method.DescendantNodes().OfType<BlockSyntax>().Count();

                int eolCount = method.DescendantTrivia().Count(n => n.Kind() == SyntaxKind.EndOfLineTrivia);
                funcInfo.Lines = eolCount;

                list.Add(funcInfo);
            }
            //    var activeSemanticModel = document.GetSemanticModelAsync().Result;

            return list;
        }
    }
}