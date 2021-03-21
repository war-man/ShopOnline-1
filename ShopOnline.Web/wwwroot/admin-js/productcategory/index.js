var ProductcategoryControl = function () {
    this.init = function () {
        loadData();
        registerEvent();
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
                    var treeArr = unflattern(data);
                    $('#ddlCategoryIdM').combotree({
                        data: treeArr
                    })
                   
                }
            }
        })
    }
    function loadDataProductCategory(id) {
        $.ajax({
            url: '/Admin/ProductCategory/FindProductCategory',
            type: 'Post',
            dataType: 'Json',
            data: {
                Id: id
            }, success: function (res) {
                if (res.status == true) {
                    var product = res.data;
                    $('#hidIdM').val(product.id);
                    $('#txtNameM').val(product.name);
                    $('#txtDescM').val(product.decripstion);
                    $('#txtOrderM').val(product.sortOrder);
                    $('#txtImage').val(product.pathImage);
                    $('#txtSeoPageTitleM').val(product.seoPageTitle);
                    $('#txtSeoAliasM').val(product.seoAlias);
                    $('#txtSeoKeywordM').val(product.seoKeywords);
                    $('#txtSeoDescriptionM').val(product.seoDescription);
                }
            }
        })
    }
    function registerEvent() {
        $('#btnSave').off('click').on('click', function () {
            var id = $('#hidIdM').val();
            var name = $('#txtNameM').val();
            var parentId = $('#ddlCategoryIdM').val();
            var decripstion = $('#txtDescM').val();
            var sortOrder = $('#txtOrderM').val();
            var pathImage = $('#txtImage').val();
            var seopagetitle = $('#txtSeoPageTitleM').val();
            var seoalias = $('#txtSeoAliasM').val();
            var seokeyword = $('#txtSeoKeywordM').val();
            var seodecripstion = $('#txtSeoDescriptionM').val();
            $.ajax({
                url: '/Admin/ProductCategory/CreatProductCategory',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Id: id,
                    Name: name,
                    Decripstion: decripstion,
                    PathImage: pathImage,
                    ParentId: parentId,
                    SortOrder: sortOrder,
                    SeoPageTitle: seopagetitle,
                    SeoAlias: seoalias,
                    SeoKeywords: seokeyword,
                    SeoDescription: seodecripstion
                }, success: function (res) {
                    if (res.status == true) {
                        if (id > 0) {
                            alert('Update is successfull');
                            window.location.href = "/Admin/ProductCategory/Index";
                        }
                        else {
                            alert('Create is successfull');
                            window.location.href = "/Admin/ProductCategory/Index";
                        }
                    }
                }
            })
        })
        $('#btnCreate').off('click').on('click', function () {
            loadCombooTree();
            $('#modal-add-edit').modal('show');
        })
        $('#btnEdit').off('click').on('click', function () {
            var id = $('#hidIdM').val();
            loadCombooTree();
            loadDataProductCategory(id);
            $('#modal-add-edit').modal('show');
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
    }
    function unflattern(arr) {
        var map = {};
        var roots = [];
        for (var i = 0; i < arr.length; i += 1) {
            var node = arr[i];
            node.children = [];
            map[node.id] = i; // use map to look-up the parents
            if (node.parentId !== null) {
                arr[map[node.parentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    }
    function loadData() {
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
                    var treeArr = unflattern(data);
                    treeArr.sort(function (a, b) {
                        return a.sortOrder - b.sortOrder;
                    });
                    $('#treeProductCategory').tree({
                        data: treeArr,
                        dnd: true,
                        onContextMenu: function (e, node) {
                            e.preventDefault();
                            // select the node
                            //$('#tt').tree('select', node.target);
                            $('#hidIdM').val(node.id);
                            // display context menu
                            $('#contextMenu').menu('show', {
                                left: e.pageX,
                                top: e.pageY
                            });
                        },
                        onDrop: function (target, source, point) {
                            console.log(target);
                            console.log(source);
                            console.log(point);
                            var targetNode = $(this).tree('getNode', target);
                            if (point === 'append') {
                                var children = [];
                                $.each(targetNode.children, function (i, item) {
                                    children.push({
                                        key: item.id,
                                        value: i
                                    });
                                });

                                //Update to database
                                $.ajax({
                                    url: '/Admin/ProductCategory/UpdateParentId',
                                    type: 'post',
                                    dataType: 'json',
                                    data: {
                                        sourceId: source.id,
                                        targetId: targetNode.id,
                                        items: children
                                    },
                                    success: function (res) {
                                        loadData();
                                    }
                                });
                            }
                            else if (point === 'top' || point === 'bottom') {
                                $.ajax({
                                    url: '/Admin/ProductCategory/ReOrder',
                                    type: 'post',
                                    dataType: 'json',
                                    data: {
                                        sourceId: source.id,
                                        targetId: targetNode.id
                                    },
                                    success: function (res) {
                                        loadData();
                                    }
                                });
                            }
                        }
                    })
                }
            }
        })
    }
}