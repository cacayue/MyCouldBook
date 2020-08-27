import { Menu } from '@delon/theme';

// 全局的左侧导航菜单
export class AppMenus {
  // new
  static Menus: Menu[] = [
    {
      text: '', // 无本地化显示字符
      i18n: 'HomePage', // 本地化主键(ABP本地化)
      acl: '', // 权限
      icon: { type: 'icon', value: 'home' }, // 图标
      link: '/app/home', // url 地址
      // hide: true,  // 强制隐藏
      // ...还有更多选项，请查看 Menu成员
    },
    {
      text: '',
      i18n: 'Tenants',
      acl: 'Pages.Tenants',
      icon: { type: 'icon', value: 'team' },
      link: '/app/tenants',
    },
    {
      text: '',
      i18n: 'Roles',
      acl: 'Pages.Roles',
      icon: { type: 'icon', value: 'safety' },
      link: '/app/roles',
    },
    {
      text: '',
      i18n: 'Users',
      acl: 'Pages.Users',
      icon: { type: 'icon', value: 'user' },
      link: '/app/users',
    },
    {
      text: '',
      i18n: 'About',
      icon: { type: 'icon', value: 'info-circle' },
      link: '/app/about',
    },
    {
      text: '',
      i18n: 'CloudBooks',
      icon: { type: 'icon', value: 'menu-unfold' },

      link: '',
      children: [
        //   {
        //     text: '',
        //     i18n: 'Books', //书籍
        //     icon: { type: 'icon', value: 'book' },
        //     link: '/app/cloud-book-list/books',
        //     acl: 'Pages.BookManager',
        //   },
        {
          text: 'Book',
          i18n: 'Book',
          acl: 'Pages.Book',
          icon: 'iconfont icon-dashboard',
          link: '/app/cloud-book-list/books',
          sort: 99,
        },
        {
          text: '',
          i18n: 'BookList', //书籍列表
          icon: 'iconfont icon-dashboard',
          acl: 'Pages.BookList',
          link: '/app/cloud-book-list/book-list',
        },
        {
          //	的菜单按钮
          text: 'BookTag',
          i18n: 'BookTag',
          acl: 'Pages.BookTag',
          icon: 'iconfont icon-dashboard',
          link: '/app/cloud-book-list/book-tag',
          sort: 99,
        },
      ],
    },
  ];
  // old
  // static Menus = [
  //     // 首页
  //     new MenuItem(
  //         'HomePage',
  //         '',
  //         'anticon anticon-home',
  //         '/app/home'
  //     ),
  //     // 租户
  //     new MenuItem(
  //         'Tenants',
  //         'Pages.Tenants',
  //         'anticon anticon-team',
  //         '/app/tenants',
  //     ),
  //     // 角色
  //     new MenuItem(
  //         'Roles',
  //         'Pages.Roles',
  //         'anticon anticon-safety',
  //         '/app/roles',
  //     ),
  //     // 用户
  //     new MenuItem(
  //         'Users',
  //         'Pages.Users',
  //         'anticon anticon-user',
  //         '/app/users',
  //     ),
  //     // 关于我们
  //     new MenuItem(
  //         'About',
  //         '',
  //         'anticon anticon-info-circle-o',
  //         '/app/about',
  //     ),
  // ];
}
