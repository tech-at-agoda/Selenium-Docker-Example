# Selenium Docker Example

Sample code is here form the [video](https://youtu.be/yGFYufxM1OE) and the [blog]()

Below is teh boiler plate chrome options I spoke about in the video

```csharp
    var chromeOptions = new ChromeOptions();
    chromeOptions.AddArguments("start-maximized"); // open Browser in maximized mode
    chromeOptions.AddArguments("disable-infobars"); // disabling infobars
    chromeOptions.AddArguments("--disable-gpu"); // applicable to windows os only
    chromeOptions.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
    chromeOptions.AddArguments("--no-sandbox"); // Bypass OS security model
    chromeOptions.AddArguments("--disable-web-security");
    chromeOptions.AddArguments("--whitelisted-ips=\"\"");
```

These are needed for chrome to work in the Linux container

in summary:

## Debug from your IDE

Run from inside src folder
```
docker-compose up --build
```

## Self Contained test run in Docker Compose

This is essentially how it should run in CI, but you can run on your local too.

```
docker-compose -f docker-compose.integration.yml -f docker-compose.yml up --build --abort-on-container-exit
```

If you needed to use this to test a web application, you could add your web app and it's dependencies into the same docker compose, and have a completely isolated test.