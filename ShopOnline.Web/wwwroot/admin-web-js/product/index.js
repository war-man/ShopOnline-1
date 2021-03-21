var ProductControl = function () {
    this.init = function () {
        registerEvent();
    }
    function registerEvent() {
        $('#input-limit').on('change', function () {
            var quantity = $(this).val();
            $.ajax({
                url: '/Product/GetAllProduct',
                type: 'Post',
                dataType: 'Json',
                data: {
                    pageSize: quantity
                }, success: function (res) {

                }
            })
        });
        $('#txtReViewProductM').off('click').on('click', function () {
            var id = $(this).data('id');
            var views = $('#review_field_product').val();
            $.ajax({
                url: '/ReViewProduct/CreatReViewProduct',
                type: 'Post',
                dataType: 'Json',
                data: {
                    review: views,
                    productId:id
                }, success: function (res) {
                    if (res.status == true) {
                        
                    }
                }
            })
        })
    }
    
}