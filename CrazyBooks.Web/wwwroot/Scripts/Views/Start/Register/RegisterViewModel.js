class RegisterViewModel
{    
    get ImageFile()
    {
        return this._imageFile;
    }
    set ImageFile(value)
    {
        this._imageFile = value;
        this.UploadFile(this._imageFile);
    }

    get ImageUrl()
    {
        if (this.ImageId === "")
        {
            return "images/default.png";
        }
        else
        {
            return "images/" + this.ImageId + ".png";
        }
    }

    constructor($RegisterService, $http/*, $ImageService*/, $window, Upload)
    {
        this.RegisterSvc = $RegisterService;
        //this.ImageSvc = $ImageService;
        this.Http = $http;
        this.Window = $window;

        this.Email = "s@s";
        this.Password = "1234";
        this.ImageId = "";
        this._imageFile = null;
        this.Uploader = Upload;
    }   

    UploadFile = function (file)
    {
        this.Window.IsLoading = true;
        //this.ImageSvc.UploadImageAsync(file)
        //let data =
        //{
        //    url: '"api/images"',
        //    data: { file: file }
        //};

        //this.Upload.upload(data)
        //    .then((response) =>
        //    {
        //        this.ImageId = response.data;
        //        this.Window.IsLoading = false;
        //    });


        this.Uploader.base64DataUrl([file]).then((urls) =>
        {
            let url = JSON.stringify(urls[0]).replace("data:image/jpeg;base64,", "");
            let config = { headers: { 'Content-Type': 'application/json' }};
            
            this.Http.post("api/images", url, config)
                .then((response) =>
                {
                    this.ImageId = response.data;
                    this.Window.IsLoading = false;
                });
        });
    };

    Register()
    {
        this.Window.IsLoading = true;
        this.RegisterSvc.RegisterAsync(this.Email, this.Password, this.ImageId)
            .then((response) =>
            {
                if (response.data !== "")
                {
                    this.Window.Token = response.data.token;
                    this.Window.LogonUser = response.data;
                }
                else
                {
                    alert("Usuario incorrecto");
                }
                this.Window.IsLoading = false;
            },
            (error) =>
            {
                alert(error.data.message);
                this.Window.Token = null;

                this.Window.IsLoading = false;
            });
    }
}

app.component('register',
{
    templateUrl: './Scripts/Views/Start/Register/RegisterView.html',
    controller: ['$RegisterService', '$http', '$window', 'Upload', RegisterViewModel],
    controllerAs: "vm"
});