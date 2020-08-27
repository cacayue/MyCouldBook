"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.CloudBookListModule = void 0;
var theme_1 = require("@delon/theme");
var localization_service_1 = require("./../../shared/i18n/localization.service");
var abp_module_1 = require("@abp/abp.module");
var shared_module_1 = require("./../../shared/shared.module");
var http_1 = require("@angular/common/http");
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var cloud_book_list_routing_module_1 = require("./cloud-book-list-routing.module");
var books_component_1 = require("./books/books.component");
var book_list_component_1 = require("./book-list/book-list.component");
var create_or_edit_book_component_1 = require("./books/create-or-edit-book/create-or-edit-book.component");
var CloudBookListModule = /** @class */ (function () {
    function CloudBookListModule() {
    }
    CloudBookListModule = __decorate([
        core_1.NgModule({
            declarations: [books_component_1.BooksComponent, book_list_component_1.BookListComponent, create_or_edit_book_component_1.CreateOrEditBookComponent],
            imports: [
                common_1.CommonModule,
                cloud_book_list_routing_module_1.CloudBookListRoutingModule,
                http_1.HttpClientModule,
                shared_module_1.SharedModule,
                abp_module_1.AbpModule,
            ],
            entryComponents: [
                books_component_1.BooksComponent,
                book_list_component_1.BookListComponent,
                create_or_edit_book_component_1.CreateOrEditBookComponent,
            ],
            providers: [localization_service_1.LocalizationService, theme_1.TitleService]
        })
    ], CloudBookListModule);
    return CloudBookListModule;
}());
exports.CloudBookListModule = CloudBookListModule;
