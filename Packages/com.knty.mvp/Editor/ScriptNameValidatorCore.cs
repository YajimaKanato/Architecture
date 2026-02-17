#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System;

namespace KNTy.MVP.Editor
{
    internal static class ScriptNameValidatorCore
    {
        static readonly NamingRule[] Rules =
        {
        new NamingRule(RuleType.GenericClass, "ModelBase", "Model"),
        new NamingRule(RuleType.BaseClass, "RuntimeModelBase", "RuntimeModel"),
        new NamingRule(RuleType.BaseClass, "ViewBase", "View"),
        new NamingRule(RuleType.GenericClass, "PresenterBase", "Presenter"),
    };

        public static void Validate(MonoScript mono)
        {
            if (mono == null) return;

            var type = mono.GetClass();
            if (type == null) return;

            foreach (var rule in Rules)
            {
                if (!MatchRule(type, rule)) continue;

                if (!type.Name.EndsWith(rule.RequiredSuffix))
                {
                    Debug.LogError(
                        $"Invalid Naming : {mono.name}\n" +
                        $"ScriptName Deriving {rule.TypeName} must end with \"{rule.RequiredSuffix}\"",
                        mono
                    );
                }
            }
        }

        static bool MatchRule(Type type, NamingRule rule)
        {
            return rule.RuleType switch
            {
                RuleType.BaseClass => IsDerivedFrom(type, rule.TypeName),
                RuleType.GenericClass => IsGenericClassDerivedFrom(type, rule.TypeName),
                RuleType.Interface => IsImplementsInterface(type, rule.TypeName),
                _ => false
            };
        }

        static bool IsDerivedFrom(Type type, string baseName)
        {
            var baseType = type.BaseType;
            while (baseType != null)
            {
                if (baseType.Name.StartsWith(baseName)) return true;
                baseType = baseType.BaseType;
            }
            return false;
        }

        static bool IsGenericClassDerivedFrom(Type type, string baseName)
        {
            var genericBaseType = type.BaseType;
            while (genericBaseType != null)
            {
                if (genericBaseType.IsGenericType && genericBaseType.GetGenericTypeDefinition().Name.StartsWith(baseName)) return true;
                genericBaseType = genericBaseType.BaseType;
            }
            return false;
        }

        static bool IsImplementsInterface(Type type, string interfaceName)
        {
            foreach (var i in type.GetInterfaces())
            {
                if (i.Name == interfaceName) return true;
            }
            return false;
        }

        enum RuleType
        {
            BaseClass,
            GenericClass,
            Interface
        }

        struct NamingRule
        {
            public readonly RuleType RuleType;
            public readonly string TypeName;
            public readonly string RequiredSuffix;

            public NamingRule(RuleType ruleType, string typeName, string requiredSuffix)
            {
                RuleType = ruleType;
                TypeName = typeName;
                RequiredSuffix = requiredSuffix;
            }
        }
    }
}
#endif