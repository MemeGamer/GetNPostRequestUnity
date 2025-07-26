# Unity C\# Simple GET \& POST Request Example

This project provides basic, beginner-friendly examples of performing **GET** and **POST** HTTP requests in Unity with C\#. It also demonstrates a simple workflow to use your own Google Drive–hosted JSON file as a live mock API source—perfect for simple prototyping, learning, and personal projects!

## 🚩 Features

- **Simple GET Request Script**
Grabs JSON data from any API endpoint, including Google Drive, and displays it directly to Unity UI components (Text, RawImage, etc.).
- **Basic POST Request Script**
Sends sample form data (`Health`) to a testing endpoint and displays the result or error in the UI.
- **Use Google Drive as a Mock API**
Easily host and access your own `data.json` for prototyping: just upload, get the link, convert to a direct download/api link, and point your Unity script to it.


## 📂 Project Structure

```
├── Demo.cs           # GET request, displays JSON info and image in Unity UI
├── PostMethod.cs     # POST request, basic form submission & result handling
├── data.json         # Example data, easy to edit and host on Google Drive
```


## 🏁 Quick Start

### 1. **Using GET with Google Drive JSON**

1. **Edit `data.json`**
You can use the sample data below or edit/add fields as you wish:

```json
{
  "Name": "Player1",
  "Health": "100",
  "Personality": "2",
  "Charm": "2",
  "Behavior": "2",
  "managment": "3",
  "ImageURL": "https://drive.google.com/uc?export=download&id=YOUR_IMAGE_ID"
}
```

(Sample uses `"Health": "100"` and links to a Google Drive-hosted image.)
2. **Upload to Google Drive**
    - Upload your `data.json` to Drive and **set file sharing to "Anyone with the link"**.
    - Get the Drive share link (ex: `https://drive.google.com/file/d/FILE_ID/view?usp=drive_link`).
3. **Convert to Direct API Link**
    - Use this tool:
[https://herbou.github.io/GoogleDriveDownloadLinkGenerator/](https://herbou.github.io/GoogleDriveDownloadLinkGenerator/)
    - Paste in your link and copy the **direct download URL** (used as JSON endpoint).
4. **Update `jsonURL` in `Demo.cs`**
Replace the sample URL with your converted drive link.

```csharp
string jsonURL = "YOUR_DIRECT_DOWNLOAD_LINK";
```

5. **Plug Unity UI Components**
Assign the Text and RawImage fields in the Unity Inspector for the script to populate them.

### 2. **Simple POST Script (`PostMethod.cs`)**

- Sends a form field to a test endpoint and displays the result in UI.
- Edit `uri`, form fields, and UI targets as desired.


## 📝 Example Scripts

### Demo.cs (GET Example)

```csharp
// Displays Name, Health, Personality, etc., and downloads & shows image

public struct Data {
    public string Name, Health, Personality, Charm, Behavior, managment, ImageURL;
}

// ... Full script loads JSON, updates Texts, downloads Image and updates RawImage ...
```


### PostMethod.cs (POST Example)

```csharp
// Posts "Health" field to mock REST API and displays result in UI

void PostData() => StartCoroutine(PostData_Coroutine());
```


## 📄 Example data.json

```json
{
  "Name": "Player1",
  "Health": "100",
  "Personality": "2",
  "Charm": "2",
  "Behavior": "2",
  "managment": "3",
  "ImageURL": "https://drive.google.com/uc?export=download&id=1w3eGumMhTyw21ur8_hkgs8l1MfQiqRM-"
}
```


## ⚡️ Tips \& Notes

- For **GET testing**: Any public direct link to raw JSON will work. For local files/test servers, use `http://localhost:PORT/file.json`.
- For **POST tests**, services like [Mocky.io], [JSONPlaceholder], or your own backend can receive simulated requests.


## 🧩 Credits

- Drive API link conversion via [herbou.github.io/GoogleDriveDownloadLinkGenerator](https://herbou.github.io/GoogleDriveDownloadLinkGenerator/)
- Image and Demo JSON hosting via Google Drive.
- Made for fast-prototyping and learning in Unity.

Enjoy prototyping CRUD and data-driven UIs in Unity—without backend headaches!

<div style="text-align: center">⁂</div>

[^1]: PostMethod.cs

[^2]: Demo.cs

[^3]: data.json

