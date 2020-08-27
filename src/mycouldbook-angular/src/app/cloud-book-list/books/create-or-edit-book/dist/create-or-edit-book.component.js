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
exports.CreateOrEditBookComponent = void 0;
var operators_1 = require("rxjs/operators");
var service_proxies_1 = require("./../../../../shared/service-proxies/service-proxies");
var core_1 = require("@angular/core");
var component_base_1 = require("@shared/component-base");
var CreateOrEditBookComponent = /** @class */ (function (_super) {
    __extends(CreateOrEditBookComponent, _super);
    function CreateOrEditBookComponent(injector, _bookService) {
        var _this = _super.call(this, injector) || this;
        _this._bookService = _bookService;
        _this.entityDto = new service_proxies_1.BookEditInput();
        return _this;
    }
    CreateOrEditBookComponent.prototype.ngOnInit = function () {
        this.init();
    };
    CreateOrEditBookComponent.prototype.init = function () {
        var _this = this;
        //获取编辑中的实体
        this._bookService.getForEditBook(this.id).subscribe(function (res) {
            _this.entityDto = res.book;
        });
    };
    //保存实体
    CreateOrEditBookComponent.prototype.submitForm = function () {
        var _this = this;
        var input = new service_proxies_1.CreateOrUpdateBookInput();
        input.book = this.entityDto;
        this.saving = true;
        this._bookService
            .createOrUpdateBook(input)
            .pipe(operators_1.finalize(function () {
            _this.saving = false;
        }))
            .subscribe(function () {
            abp.notify.success('信息保存成功');
            _this.success(true);
        });
    };
    CreateOrEditBookComponent = __decorate([
        core_1.Component({
            selector: 'app-create-or-edit-book',
            templateUrl: './create-or-edit-book.component.html',
            styles: []
        })
    ], CreateOrEditBookComponent);
    return CreateOrEditBookComponent;
}(component_base_1.ModalComponentBase));
exports.CreateOrEditBookComponent = CreateOrEditBookComponent;
