﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web.Bootstrap;
using Havit.Blazor.Components.Web.Messenger;
using Havit.GoranG3.Contracts.System;
using Microsoft.AspNetCore.Components;

namespace Havit.GoranG3.Web.Client.Pages.Admin.Components
{
	public partial class DataSeeds : ComponentBase
	{
		[Inject] protected IDataSeedFacade DataSeedFacade { get; set; }
		[Inject] protected IHxMessengerService Messenger { get; set; }

		private IEnumerable<string> seedProfiles;
		private FormModel model = new FormModel();

		protected override async Task OnInitializedAsync()
		{
			this.seedProfiles = (await DataSeedFacade.GetDataSeedProfiles()).Value;
		}

		private async Task HandleValidSubmit()
		{
			await DataSeedFacade.SeedDataProfile(model.SelectedSeedProfile);
			Messenger.AddInformation($"Seed successful: {model.SelectedSeedProfile}");
		}

		public class FormModel
		{
			[Required]
			public string SelectedSeedProfile { get; set; }
		}
	}
}
