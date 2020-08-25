"use strict";
exports.__esModule = true;
exports.AppMenus = void 0;
// 全局的左侧导航菜单
var AppMenus = /** @class */ (function () {
    function AppMenus() {
    }
    // new
    AppMenus.Menus = [
        {
            text: '',
            i18n: 'HomePage',
            acl: '',
            icon: { type: 'icon', value: 'home' },
            link: '/app/home'
        },
        {
            text: '',
            i18n: 'Tenants',
            acl: 'Pages.Tenants',
            icon: { type: 'icon', value: 'team' },
            link: '/app/tenants'
        },
        {
            text: '',
            i18n: 'Roles',
            acl: 'Pages.Roles',
            icon: { type: 'icon', value: 'safety' },
            link: '/app/roles'
        },
        {
            text: '',
            i18n: 'Users',
            acl: 'Pages.Users',
            icon: { type: 'icon', value: 'user' },
            link: '/app/users'
        },
        {
            text: '',
            i18n: 'About',
            icon: { type: 'icon', value: 'info-circle' },
            link: '/app/about'
        },
        {
            text: '',
            i18n: 'CloudBooks',
            icon: { type: 'icon', value: 'menu-unfold' },
            link: '',
            children: [
                {
                    text: '',
                    i18n: 'Books',
                    icon: { type: 'icon', value: 'book' },
                    link: '/app/cloud-book-list/books'
                },
                {
                    text: '',
                    i18n: 'BookList',
                    icon: { type: 'icon', value: 'ordered-list' },
                    link: '/app/cloud-book-list/book-list'
                },
            ]
        },
    ];
    return AppMenus;
}());
exports.AppMenus = AppMenus;
