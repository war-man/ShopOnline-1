var LoginControl = function () {
    this.init = function () {
        registerEvent();
    }
    function registerEvent() {
        $('#txtLogin').off('click').on('click', function () {
            var username = $('#txtUserName').val();
            var password = $('#txtPassword').val();
            $.ajax({
                type: 'Post',
                url: '/Admin/Login/Login',
                data: {
                    UserName: username,
                    Password: password
                },
                dataType: 'Json',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href="/Admin/Home/Index"
                    }
                }
            });
        })
    }
}