// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Deletes the Secret resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "SFMeshSecret", DefaultParameterSetName = "Delete")]
    public partial class RemoveMeshSecretCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets SecretResourceName. The name of the secret resource.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Delete")]
        public string SecretResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the force flag. If provided, then the destructive action will be performed without asking for
        /// confirmation prompt.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Delete")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            if (((this.Force != null) && this.Force) || this.ShouldContinue(string.Empty, string.Empty))
            {
                this.ServiceFabricClient.MeshSecrets.DeleteAsync(
                    secretResourceName: this.SecretResourceName,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
        }
    }
}
