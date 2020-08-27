"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.BooksComponent = void 0;
var operators_1 = require("rxjs/operators");
var _ = require("lodash");
var routerTransition_1 = require("@shared/animations/routerTransition");
var core_1 = require("@angular/core");
var component_base_1 = require("@shared/component-base");
var create_or_edit_book_component_1 = require("./create-or-edit-book/create-or-edit-book.component");
var BooksComponent = /** @class */ (function (_super) {
    __extends(BooksComponent, _super);
    function BooksComponent(injector, _bookService) {
        var _this = _super.call(this, injector) || this;
        _this._bookService = _bookService;
        return _this;
    }
    /**
     * 默认获取后端分页数据列表
     * @param request 请求数据参数
     * @param pageNumber  当前页码
     * @param finishedCallback 完成后的回调
     */
    BooksComponent.prototype.fetchDataList = function (request, pageNumber, finishedCallback) {
        var _this = this;
        this._bookService
            .getPagedBooks(this.filterText, request.sorting, request.maxResultCount, request.skipCount)
            .pipe(operators_1.finalize(function () {
            finishedCallback();
        }))
            .subscribe(function (result) {
            _this.dataList = result.items;
            _this.showPaging(result);
        });
    };
    BooksComponent.prototype["delete"] = function (entityDto) {
        var _this = this;
        this._bookService.deleteBook(entityDto.id).subscribe(function () {
            _this.refreshGoFirstPage();
            abp.notify.success('信息已删除!');
        });
    };
    BooksComponent.prototype.batchDelete = function () {
        var _this = this;
        var selectedCount = this.selectedDataItems.length;
        if (selectedCount <= 0) {
            abp.message.warn('请选择所需要的删除的书籍!');
            return;
        }
        abp.message.confirm('是否确认删除', '删除选中数据', function (res) {
            if (res) {
                var ids = _.map(_this.selectedDataItems, 'id');
                _this._bookService.batchDeleteBook(ids).subscribe(function () {
                    _this.refreshGoFirstPage();
                    abp.notify.success('信息已删除!');
                });
            }
        });
    };
    BooksComponent.prototype.createOrEdit = function (id) {
        var _this = this;
        this.modalHelper
            .static(create_or_edit_book_component_1.CreateOrEditBookComponent, { id: id })
            .subscribe(function (result) {
            if (result) {
                _this.refresh();
            }
        });
    };
    BooksComponent = __decorate([
        core_1.Component({
            selector: 'app-books',
            templateUrl: './books.component.html',
            styles: ['./books.component.less'],
            animations: [routerTransition_1.appModuleAnimation()]
        })
    ], BooksComponent);
    return BooksComponent;
}(component_base_1.PagedListingComponentBase));
exports.BooksComponent = BooksComponent;
