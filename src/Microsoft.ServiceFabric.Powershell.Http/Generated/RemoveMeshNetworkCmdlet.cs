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
    /// Deletes the Network resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "SFMeshNetwork", DefaultParameterSetName = "Delete")]
    public partial class RemoveMeshNetworkCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NetworkResourceName. The identity of the network.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Delete")]
        public string NetworkResourceName
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
                this.ServiceFabricClient.MeshNetworks.DeleteAsync(
                    networkResourceName: this.NetworkResourceName,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
        }
    }
}