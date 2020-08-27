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
exports.RolesComponent = void 0;
var core_1 = require("@angular/core");
var paged_listing_component_base_1 = require("@shared/component-base/paged-listing-component-base");
var edit_role_component_1 = require("@app/roles/edit-role/edit-role.component");
var create_role_component_1 = require("@app/roles/create-role/create-role.component");
var RolesComponent = /** @class */ (function (_super) {
    __extends(RolesComponent, _super);
    function RolesComponent(injector, rolesService) {
        var _this = _super.call(this, injector) || this;
        _this.rolesService = rolesService;
        return _this;
    }
    RolesComponent.prototype.fetchDataList = function (request, pageNumber, finishedCallback) {
        var _this = this;
        this.rolesService
            .getAll('', request.skipCount, request.maxResultCount)["finally"](function () {
            finishedCallback();
        })
            .subscribe(function (result) {
            _this.dataList = result.items;
            _this.totalItems = result.totalCount;
        });
    };
    RolesComponent.prototype["delete"] = function (entity) {
        var _this = this;
        this.message.confirm("Remove Users from Role and delete Role '" + entity.displayName + "'?", 'Permanently delete this Role', function (result) {
            if (result) {
                _this.rolesService["delete"](entity.id)["finally"](function () {
                    _this.notify.info('Deleted Role: ' + entity.displayName);
                    _this.refresh();
                })
                    .subscribe(function () { });
            }
        });
    };
    RolesComponent.prototype.create = function () {
        var _this = this;
        this.modalHelper
            .open(create_role_component_1.CreateRoleComponent, {}, 'md', {
            nzMask: true
        })
            .subscribe(function (isSave) {
            if (isSave) {
                _this.refresh();
            }
        });
    };
    RolesComponent.prototype.edit = function (item) {
        var _this = this;
        this.modalHelper
            .open(edit_role_component_1.EditRoleComponent, { id: item.id }, 'md', {
            nzMask: true
        })
            .subscribe(function (isSave) {
            if (isSave) {
                _this.refresh();
            }
        });
    };
    RolesComponent = __decorate([
        core_1.Component({
            selector: 'app-roles',
            templateUrl: './roles.component.html',
            styles: []
        })
    ], RolesComponent);
    return RolesComponent;
}(paged_listing_component_base_1.PagedListingComponentBase));
exports.RolesComponent = RolesComponent;
