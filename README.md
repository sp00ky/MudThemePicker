# MudThemePicker

## Fixing the MudPopoverProvider error

When running the demo you may see the following exception:

```
Missing <MudPopoverProvider />, please add it to your layout.
```

MudBlazor components that open content outside of the normal render tree (like popovers) need a dedicated provider component. Make sure your root layout (for example `src/MudThemePicker.Demo/Shared/MainLayout.razor`) includes the MudBlazor provider stack:

```razor
<MudThemeProvider />
<MudDialogProvider />
<MudSnackbarProvider />
<MudPopoverProvider />

@Body
```

The sample layout in `src/MudThemePicker.Demo/Shared/MainLayout.razor` already contains the required `<MudPopoverProvider />` so you can copy it into your app or use it as-is.
