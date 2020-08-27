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
exports.TenantsComponent = void 0;
var core_1 = require("@angular/core");
var edit_tenant_component_1 = require("@app/tenants/edit-tenant/edit-tenant.component");
var paged_listing_component_base_1 = require("@shared/component-base/paged-listing-component-base");
var create_tenant_component_1 = require("@app/tenants/create-tenant/create-tenant.component");
var TenantsComponent = /** @class */ (function (_super) {
    __extends(TenantsComponent, _super);
    function TenantsComponent(injector, _tenantService) {
        var _this = _super.call(this, injector) || this;
        _this._tenantService = _tenantService;
        return _this;
    }
    TenantsComponent.prototype.fetchDataList = function (request, pageNumber, finishedCallback) {
        var _this = this;
        this._tenantService
            .getAll('', this.isActive, request.skipCount, request.maxResultCount)["finally"](function () {
            finishedCallback();
        })
            .subscribe(function (result) {
            _this.dataList = result.items;
            _this.totalItems = result.totalCount;
        });
    };
    TenantsComponent.prototype.create = function () {
        var _this = this;
        this.modalHelper
            .open(create_tenant_component_1.CreateTenantComponent, {}, 'md', {
            nzMask: true
        })
            .subscribe(function (isSave) {
            if (isSave) {
                _this.refresh();
            }
        });
    };
    TenantsComponent.prototype.edit = function (item) {
        var _this = this;
        this.modalHelper
            .open(edit_tenant_component_1.EditTenantComponent, { id: item.id }, 'md', {
            nzMask: true
        })
            .subscribe(function (isSave) {
            if (isSave) {
                _this.refresh();
            }
        });
    };
    TenantsComponent.prototype["delete"] = function (item) {
        var _this = this;
        this.message.confirm("Delete tenant '" + item.name + "'?", undefined, function (result) {
            if (result) {
                _this._tenantService["delete"](item.id)["finally"](function () {
                    _this.notify.info('Deleted tenant: ' + item.name);
                    _this.refresh();
                })
                    .subscribe(function () { });
            }
        });
    };
    TenantsComponent = __decorate([
        core_1.Component({
            selector: 'app-tenants',
            templateUrl: './tenants.component.html',
            styles: []
        })
    ], TenantsComponent);
    return TenantsComponent;
}(paged_listing_component_base_1.PagedListingComponentBase));
exports.TenantsComponent = TenantsComponent;
