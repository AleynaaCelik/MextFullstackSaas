﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MextFullStackSaas.Application.Resources.Common.Translations {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CommonTranlations_en_GB {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonTranlations_en_GB() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MextFullStackSaas.Application.Resources.Common.Translations.CommonTranlations-en-" +
                            "GB", typeof(CommonTranlations_en_GB).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Verify Email.
        /// </summary>
        internal static string EmailVerificationButtonText {
            get {
                return ResourceManager.GetString("EmailVerificationButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Kindly click the button below to confirm your email address..
        /// </summary>
        internal static string EmailVerificationContent {
            get {
                return ResourceManager.GetString("EmailVerificationContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email Verification.
        /// </summary>
        internal static string EmailVerificationSubject {
            get {
                return ResourceManager.GetString("EmailVerificationSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password reset email sent successfully to {0}.
        /// </summary>
        internal static string ForgotPasswordSuccessMessage {
            get {
                return ResourceManager.GetString("ForgotPasswordSuccessMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected error occurred on the server side..
        /// </summary>
        internal static string GeneralServerExceptionMessage {
            get {
                return ResourceManager.GetString("GeneralServerExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more validation errors occurred..
        /// </summary>
        internal static string GeneralValidationExceptionMessage {
            get {
                return ResourceManager.GetString("GeneralValidationExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to reset password for {0}.
        /// </summary>
        internal static string ResetPasswordFailureMessage {
            get {
                return ResourceManager.GetString("ResetPasswordFailureMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password reset successfully for {0}.
        /// </summary>
        internal static string ResetPasswordSuccessMessage {
            get {
                return ResourceManager.GetString("ResetPasswordSuccessMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string UserAuthLoginSucceddedMessage {
            get {
                return ResourceManager.GetString("UserAuthLoginSucceddedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to our application :).
        /// </summary>
        internal static string UserAuthRegisterSucceddedMessage {
            get {
                return ResourceManager.GetString("UserAuthRegisterSucceddedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} Your email address verified succsessfully..
        /// </summary>
        internal static string UserAuthVerifyEmailSuccededMessage {
            get {
                return ResourceManager.GetString("UserAuthVerifyEmailSuccededMessage", resourceCulture);
            }
        }
    }
}
