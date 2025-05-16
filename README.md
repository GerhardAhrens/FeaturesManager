# FeaturesManager

![NET](https://img.shields.io/badge/NET-8.0-green.svg)
![License](https://img.shields.io/badge/License-MIT-blue.svg)
![VS2022](https://img.shields.io/badge/Visual%20Studio-2022-white.svg)
![Version](https://img.shields.io/badge/Version-1.0.2025.0-yellow.svg)]

Beispiel zum aktivieren, Deaktivieren von Features in einer Anwendung. Es gibt Gründe, das die eine oder andere neue Funktion nicht gleich für alle Anwender zur Verfügung stehen soll. Mit dem Feature Manager wird eine Möglichkeit zur Verwaltung und Freigabe zur Verfügung gestellt.

Alle möglichen Feature werden mit einem Default Key-Wert in eine JSON Datei geschrieben. 

```JSON
[
	{"Key":"00000001-0000-0000-0000-000000000000","Description":"Feature A"},
	{"Key":"00000002-0000-0000-0000-000000000000","Description":"Feature B"}
]
```

In der Anwendung selbst gibt es eine Enum-Klasse die, die Feature repräsentieren sollen.

```csharp
public enum FeaturesTyp : int
{
    [Feature("C8363A8B-4456-4A58-BAA8-CCDB19B4EF0C","Feature A")]
    Features1 = 1,
    [Feature("0470FBCD-C6A7-4E2D-BFD9-5E220B89AD0B", "Feature B")]
    Features2 = 2,
}
```

Dann noch die Logik um zu prüfen ob ein Feature aktiviert werden kann. In diesem einfachen Beispiel wird einfach ein Button angezeigt oder nicht.
```csharp
private void OnLoaded(object sender, RoutedEventArgs e)
{
    FeaturesTyp featureA = FeaturesTyp.Features1;
    bool featureFoundA = ApplicationFeatures.HasFeatures(featureA);
    if (featureFoundA == true)
    {
        FeaturesResult result = ApplicationFeatures.Get(featureA);
        if (result != null)
        {
            this.BtnFunktionA.Visibility = Visibility.Visible;
            this.BtnFunktionA.Content = result.Description;
        }
    }
    else
    {
        this.BtnFunktionA.Visibility = Visibility.Collapsed;
    }

    FeaturesTyp featureB = FeaturesTyp.Features2;
    bool featureFoundB = ApplicationFeatures.HasFeatures(featureB);
    if (featureFoundB == true)
    {
        FeaturesResult result = ApplicationFeatures.Get(featureB);
        if (result != null)
        {
            this.BtnFunktionB.Visibility = Visibility.Visible;
            this.BtnFunktionB.Content = result.Description;
        }
    }
    else
    {
        this.BtnFunktionB.Visibility = Visibility.Collapsed;
    }
}
```
