var ProductControl = function () {
    var images = [];
    
    var listproductCategories = [];
    var colors = [];
    var sizes = [];
    this.init = function () {
        loadListProductCategory();
        loadListColor();
        loadListSize();
        loadData();
        registerEvent();
    }
    function loadWholePriceByProductId(id) {
        $.ajax({
            url: '/Admin/Product/GetAllWholePriceByProductId',
            type: 'Post',
            dataType: 'Json',
            data: {
                Id: id
            }, success: function (res) {
                if (res.status == true) {
                    var listwholePrice = res.data;
                    var ren = '';
                    var template = $('#template-table-whole-price').html();
                    $.each(listwholePrice, function (i, item) {
                        ren += Mustache.render(template, {
                            Id:item.id,
                            FromQuantity: item.fromQuantity,
                            ToQuantity: item.toQuantity,
                            Price: item.price
                        })
                    })
                    $('#table-content-whole-price').html(ren);
                }
            }
        })
    }
    function loadProductQuantityByProductId(id) {
        $.ajax({
            url: '/Admin/Product/GetListProductQuantityByProductId',
            type: 'Post',
            dataType: 'Json',
            data: {
                Id: id
            }, success: function (res) {
                if (res.status == true) {
                    var listproductquantity = res.data;
                    var ren = '';
                    var template = $('#template-table-quantity').html();
                    $.each(listproductquantity, function (i, item) {
                        ren += Mustache.render(template, {
                            Colors: getddlProductColor(item.productColorId),
                            Sizes: getddlProductSize(item.productSizeId),
                            Quantity: item.quantity
                        })
                    })
                    $('#table-quantity-content').html(ren);
                }
            }

        })
    }
    function loadImages() {

        $.ajax({
            url: '/Admin/ProductImage/GetListProductImageByProductId',
            data: {
                Id: $('#hidId').val()
            },
            type: 'Post',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    var listproductImage = res.data;
                    var render = '';
                    $.each(listproductImage, function (i, item) {
                        render += '<div class="col-md-3"><img width="100" src="' + item.pathImage + '"><br/><a class="btn-delete-image" data-id="' + item.id + '">Xóa</a></div>'
                    });
                    $('#image-list').html(render);
                }
            }
        });
    }
    function loadCombooTree() {
        $.ajax({
            url: '/Admin/ProductCategory/GetAllProductCategory',
            type: 'Post',
            dataType: 'Json',
            
            success: function (res) {
                if (res.status == true) {
                    var listproductcategory = res.data;
                    var data = [];
                    $.each(listproductcategory, function (i, item) {
                        data.push({
                            id: item.id,
                            text: item.name,
                            parentId: item.parentId,
                            sortOrder: item.sortOrder
                        })
                    })
                    var treeArr = tedu.unflattern(data);
                    $('#ddlCategoryIdM').combotree({
                        data: treeArr
                    })

                }
            }
        })
    }
    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: "/Admin/ProductCategory/GetAllProductCategory",
            type: 'Post',
            dataType: 'json',
           
            success: function (response) {
                var list = response.data;
                var data = [];
                $.each(list, function (i, item) {
                    data.push({
                        id: item.id,
                        text: item.name,
                        parentId: item.parentId,
                        sortOrder: item.sortOrder
                    });
                });
                var arr = tedu.unflattern(data);
                $('#ddlCategoryIdM').combotree({
                    data: arr
                });

                $('#ddlCategoryIdImportExcel').combotree({
                    data: arr
                });
                if (selectedId != undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }
    function registerEvent() {
        $('body').on('click', '.btn-delete', function () {
            var id = $(this).data('id');
            $.ajax({
                url: '/Admin/Product/DeleteProduct',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Id: id
                }, success: function (res) {
                    if (res.status == true) {
                        alert('Delete is success full');
                        window.location.href='/Admin/Product/Index'
                    }
                }
            })
        })
        $('#btn-import').off('click').on('click', function () {
            initTreeDropDownCategory();
            $('#modal-import-excel').modal('show');
        })
        $('#btn-export').off('click').on('click', function () {
            $.ajax({
                type: 'Post',
                url: '/Admin/Product/ExportExcel',
                dataType: 'Json',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href=res.data
                    }
                }
            });
        });
        $('#btnImportExcel').on('click', function () {
            var fileUpload = $("#fileInputExcel").get(0);
            var files = fileUpload.files;
            // Create FormData object
            var fileData = new FormData();
            // Looping over all files and add it to FormData object
            for (var i = 0; i < files.length; i++) {
                fileData.append("files", files[i]);
            }
            // Adding one more key to FormData object
            fileData.append('categoryId', $('#ddlCategoryIdImportExcel').combotree('getValue'));
            $.ajax({
                url: '/Admin/Product/ImportExcel',
                type: 'POST',
                data: fileData,
                processData: false,  // tell jQuery not to process the data
                contentType: false,  // tell jQuery not to set contentType
                success: function (data) {
                    $('#modal-import-excel').modal('hide');
                    loadData();

                }
            });
            return false;
        });
        $('#btnSaveWholePrice').off('click').on('click', function () {
            var data = [];
            $.each($('#table-content-whole-price tr'), function (i, item) {
                data.push({
                    
                    FromQuantity: $(item).find('input.txtQuantityFrom').first().val(),
                    ToQuantity: $(item).find('input.txtQuantityTo').first().val(),
                    Price: $(item).find('input.txtWholePrice').first().val(),
                    
                })
            })
            $.ajax({
                url: '/Admin/Product/CreatWholePrice',
                type: 'Post',
                dataType: 'Json',
                data: {
                    productId: $('#txtWholePriceHidenId').val(),
                    Value: JSON.stringify(data)
                }, success: function (res) {
                    if (res.status == true) {
                        alert('Creat is successfull');
                        window.location.href="/Admin/Product/Index"
                    }
                }
            })
        })
        $('body').on('click', '.btn-delete-whole-price', function () {
            var id = $(this).data('id');
            if (id > 0) {
                $.ajax({
                    url: '/Admin/Product/DeleteWholePrice',
                    type: 'Post',
                    dataType: 'Json',
                    data: {
                        Id: id
                    }, success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/Admin/Product/Index"
                        }
                    }
                })
            }
            else {
                $(this).closest('tr').remove();
            }

        })
        $('#btn-add-whole-price').off('click').on('click', function () {
            var ren = '';
            var fromquantity = null;
            var toQuantity = null;
            var price = null;
            var template = $('#template-table-whole-price').html();
            ren = Mustache.render(template, {
                FromQuantity: fromquantity,
                ToQuantity: toQuantity,
                Price: price
            });
            $('#table-content-whole-price').append(ren);
        })
       
        $('body').on('click', '.btn-whole-price', function () {
            var id = $(this).data('id');
            $('#txtWholePriceHidenId').val(id);
            loadWholePriceByProductId(id);
            $('#modal-whole-price').modal('show');

        })
        $('#btnSaveQuantity').off('click').on('click', function () {
            var data = [];
            $.each($('#table-quantity-content tr'), function (i, item) {
                data.push({
                    ProductColorId: $(item).find('select.txtddlColor').first().val(),
                    ProductSizeId: $(item).find('select.txtddlSize').first().val(),
                    Quantity: $(item).find('input.txtQuantity').first().val(),
                })
            })
            $.ajax({
                url: '/Admin/Product/CreatProductQuantity',
                type: 'Post',
                dataType: 'Json',
                data: {
                    productId: $('#hidId').val(),
                    Value: JSON.stringify(data)
                }, success: function (res) {
                    if (res.status == true) {
                        alert('Create is successfull');
                        window.location.href = "/Admin/Product/Index"
                    }
                }
            })
        })
        $('body').on('click', '.btn-delete-quantity', function (e) {
            $(this).closest('tr').remove();
        })
        $('body').on('click', '#btn-add-quantity', function (e) {
            var ren = '';
            var quantity = null;
            var template = $('#template-table-quantity').html();
            ren = Mustache.render(template, {
                Colors: getddlProductColor(),
                Sizes: getddlProductSize(),
                Quantity: quantity
            });
            $('#table-quantity-content').append(ren);
        })
        $('body').on('click', '.btn-quantity', function (e) {
            var id = $(this).data('id');
            $('#hidId').val(id);
            loadProductQuantityByProductId(id);
            $('#modal-quantity-management').modal('show')
        })
        $('body').on('click', '.btn-delete-image', function () {
            var id = $(this).data('id');
            $.ajax({
                url: '/Admin/ProductImage/DeleteProductImage',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Id: id
                }, success: function (res) {
                    if (res.status == true) {
                        alert('Delete is successfull')
                    }
                }
            })
        });
        $('body').on('click', '.txtdeleteListImage', function (e) {
            $(this).closest('img').remove();
        })
        $("#btnSaveImages").off('click').on('click', function () {
            var imageList = [];
            $.each($('#image-list').find('img'), function (i, item) {
                imageList.push($(this).data('path'));
            });
            $.ajax({
                url: '/Admin/ProductImage/CreatProductImage',
                data: {
                    productId: $('#hidId').val(),
                    images: images
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    $('#modal-image-manage').modal('hide');
                    $('#image-list').html('');
                    window.location.href="/Admin/Product/Index"
                }
            });
        });
        $("#fileImage").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    images.push(path);
                    $('#image-list').append('<div class="col-md-3"><img width="100"  data-path="' + path + '" src="' + path + '"><a class="txtdeleteListImage">DeleteImage</a></div>');
                },

            });
        });
        $('body').on('click', '.btn-images', function () {
            var that = $(this).data('id');
            $('#hidId').val(that);
            loadImages();
            $('#modal-image-manage').modal('show');
        });
        $('#btnSave').off('click').on('click', function () {
            var id = $('#hidIdM').val();
            var name = $('#txtNameM').val();
            var productcategory = $('#ddlCategoryIdM').val();
            var decripstion = $('#txtDescM').val();
            var price = $('#txtPriceM').val();
            var lastprice = $('#txtOriginalPriceM').val();
            var pathimage = $('#txtImage').val();
            var seotitle = $('#txtSeoPageTitleM').val();
            var seokeyword = $('#txtMetakeywordM').val();
            var seoalias = $('#txtSeoAliasM').val();
            var seodecripstion = $('#txtMetaDescriptionM').val();
            $.ajax({
                url: '/Admin/Product/CreatProduct',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Id:id,
                    Name: name,
                    Price: price,
                    LastPrice: lastprice,
                    Decripstion: decripstion,
                    ProductCategoryId: productcategory,
                    PathImage: pathimage,
                    SeoTitle: seotitle,
                    SeoKeyword: seokeyword,
                    SeoAlias: seoalias,
                    SeoDecripstion: seodecripstion
                }, success: function (res) {
                    if (res.status == true) {
                        if (id > 0) {
                            alert('Update is successfull');

                            window.location.href = "/Admin/Product/Index"
                        }
                        else {
                            alert('Creat is successfull');

                            window.location.href = "/Admin/Product/Index"
                        }
                    }
                }
            })
        })
        $('#btnSelectImg').on('click', function () { // image Manager
            $('#fileInputImage').click();
        }); // Image Manager
        $("#fileInputImage").on('change', function () { // image Manager
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $('#txtImage').val(path);
                    $('#txtUpadateImageTest').html('<div  class="col-md-3"><img src="' + path + '" alt="" width="100" height="100"></div>')
                },

            });
        });  // Image Manager
        $('#btnCreate').off('click').on('click', function () {
            loadCombooTree();
            $('#modal-add-edit').modal('show')
        })
    }
    function loadData(isPageChanged) {
        $('#ddlshowpage').on('change', function () {
            tedu.configs.pageSize = $(this).val();
            tedu.configs.pageIndex = 1;
            loadData(true);
        });
        $.ajax({
            url: '/Admin/Product/GetAllProductPaging',
            type: 'Post',
            dataType: 'Json',
            data: {
                keyword: $('#txtKeyword').val(),
                pageIndex: tedu.configs.pageIndex,
                pageSize: tedu.configs.pageSize
            },
            success: function (response) {
                var listUser = response.items;
                var ren = '';
                var template = $('#table-template').html();
                $.each(listUser, function (i, item) {
                    ren += Mustache.render(template, {
                        Id: item.id,
                        Name: item.name,
                        Price: item.price,
                        LastPrice: item.lastPrice,
                        PathImage: '<img src="' + item.pathImage + '" alt="Girl in a jacket" width="50" height="50">',
                        ProductCategoryId: getddlProductCategory(item.productCategoryId)
                    })
                })
                $('#tbl-content').html(ren);
                wrapPaging(response.totalRecords, function () {
                    loadData();
                }, isPageChanged);
            }
        })
    }
    function loadListProductCategory() {
        $.ajax({
            url: '/Admin/ProductCategory/GetAll',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var listproductcategory = res.data;
                    listproductCategories = listproductcategory;
                }
            }
        })
    }
    function getddlProductCategory(id) {
        var ren = '<select class="txtddlProductCategory">';
        if (id > 0) {
            $.each(listproductCategories, function (i, item) {
                if (item.id === id) {
                    ren += '<option value="' + item.id + '">' + item.name + '</option>'
                }
            })
        }
        else {
            $.each(productcategory, function (i, item) {
                ren += '<option value="' + item.id + '">' + item.name + '</option>'
            })
        }
        ren += '</select>';
        return ren;
    }
    function loadListColor() {
        $.ajax({
            url: '/Admin/Product/GetListProductColor',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var listcolor = res.data;
                    colors = listcolor;
                }
            }
        })
    }
    function loadListSize() {
        $.ajax({
            url: '/Admin/Product/GetListProductSize',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var listsize = res.data;
                    sizes = listsize;
                }
            }
        })
    }
    function getddlProductColor(id) {
        var ren = '<select class="txtddlColor">';
        if (id > 0) {
            var listcolors = colors;
            $.each(colors, function (i, item) {
                if (item.id === id) {
                    ren += '<option value="' + item.id + '">' + item.name + '</option>'
                }
            })
        }
        else {
            $.each(colors, function (i, item) {
                ren += '<option value="' + item.id + '">' + item.name + '</option>'
            })
        }
        ren += '</select>';
        return ren;
    }
    function getddlProductSize(id) {
        var ren = '<select class="txtddlSize">';
        if (id > 0) {
            var listsizes = sizes;
            $.each(sizes, function (i, item) {
                if (item.id === id) {
                    ren += '<option value="' + item.id + '">' + item.name + '</option>'
                }
            })
        }
        else {
            $.each(sizes, function (i, item) {
                ren += '<option value="' + item.id + '">' + item.name + '</option>'
            })
        }
        ren += '</select>';
        return ren;
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / tedu.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                tedu.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}