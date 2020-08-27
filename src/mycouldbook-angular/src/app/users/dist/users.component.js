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
exports.UsersComponent = void 0;
var core_1 = require("@angular/core");
var paged_listing_component_base_1 = require("@shared/component-base/paged-listing-component-base");
var create_user_component_1 = require("@app/users/create-user/create-user.component");
var edit_user_component_1 = require("@app/users/edit-user/edit-user.component");
var UsersComponent = /** @class */ (function (_super) {
    __extends(UsersComponent, _super);
    function UsersComponent(injector, _userService) {
        var _this = _super.call(this, injector) || this;
        _this._userService = _userService;
        return _this;
    }
    UsersComponent.prototype.fetchDataList = function (request, pageNumber, finishedCallback) {
        var _this = this;
        this._userService
            .getAll('', this.isActive, request.skipCount, request.maxResultCount)["finally"](function () {
            finishedCallback();
        })
            .subscribe(function (result) {
            _this.dataList = result.items;
            _this.totalItems = result.totalCount;
        });
    };
    UsersComponent.prototype["delete"] = function (entity) {
        var _this = this;
        this.message.confirm("Delete user '" + entity.fullName + "'?", undefined, function (result) {
            if (result) {
                _this._userService["delete"](entity.id).subscribe(function () {
                    _this.notify.info('Deleted User: ' + entity.fullName);
                    _this.refresh();
                });
            }
        });
    };
    UsersComponent.prototype.create = function () {
        var _this = this;
        this.modalHelper
            .open(create_user_component_1.CreateUserComponent, {}, 'md', {
            nzMask: true
        })
            .subscribe(function (isSave) {
            if (isSave) {
                _this.refresh();
            }
        });
    };
    UsersComponent.prototype.edit = function (item) {
        var _this = this;
        this.modalHelper
            .open(edit_user_component_1.EditUserComponent, { id: item.id }, 'md', {
            nzMask: true
        })
            .subscribe(function (isSave) {
            if (isSave) {
                _this.refresh();
            }
        });
    };
    UsersComponent = __decorate([
        core_1.Component({
            selector: 'app-users',
            templateUrl: './users.component.html',
            styles: []
        })
    ], UsersComponent);
    return UsersComponent;
}(paged_listing_component_base_1.PagedListingComponentBase));
exports.UsersComponent = UsersComponent;
