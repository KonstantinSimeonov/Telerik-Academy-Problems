(function () {
    'use strict';

    let phones = [
        {
            name: 'Samsung Galaxy s5',
            imgUrl: 'http://images.samsung.com/is/image/samsung/bg_SM-G900FZNABGL_001_front_black?$DT-Gallery$',
            price: 'hilqdi pari'
        },
        {
            name: 'Samsung Galaxy s6',
            imgUrl: 'http://images.samsung.com/is/image/samsung/bg_SM-G920FZKABGL_008_Front_black?$DT-Gallery$',
            price: 'milioni pari'
        },
        {
            name: 'Nokia lumia 630',
            imgUrl: 'https://i-1.prod-cdn.webapps.microsoft.com/r/image/view/-/3691696/extraHighRes/1/-/Nokia-Lumia-630-hero-jpg.jpg',
            price: 'miliardi pari'
        },
        {
            name: 'Nokia',
            imgUrl: 'http://cdn1.knowyourmobile.com/sites/knowyourmobilecom/files/styles/gallery_wide/public/2/99/6110.jpg?itok=cFH-zVOm',
            price: 'priceless'
        },
    ];

    let tablets = [
        {
            name: 'Some tablet',
            imgUrl: 'http://www.lenovo.com/images/gallery/1060x596/lenovo-tablet-yoga-10-stand-mode-5.jpg',
            price: 10
        },
        {
            name: 'Another tablet',
            imgUrl: 'http://www.lenovo.com/images/gallery/1060x596/lenovo-tablet-yoga-10-stand-mode-5.jpg',
            price: 15
        },
        {
            name: 'Some third tablet',
            imgUrl: 'http://www.lenovo.com/images/gallery/1060x596/lenovo-tablet-yoga-10-stand-mode-5.jpg',
            price: 69
        }
    ];

    let wearables = [
        {
            name: 'Sony watches',
            imgUrl: 'http://usa.chinadaily.com.cn/world/attachement/jpg/site1/20130919/180373cf843213a5661641.jpg',
            price: 111
        },
        {
            name: 'Black and purple headphones',
            imgUrl: 'http://www.gadgetreview.com/wp-content/uploads/2014/04/STREAMZ-01.jpg',
            price: 15
        },
        {
            name: 'Flower pot',
            imgUrl: 'http://www.digitaljournal.com/img/9/3/7/4/9/3/i/1/6/1/p-large/i-4.jpg',
            price: 9999999
        }
    ];

    let baseUrl = 'http://localhost:6969/';

    module.exports = {
        phones: phones,
        tablets: tablets,
        wearables: wearables,
        links: [
            {
                title: 'Home',
                url: baseUrl + 'home'
            },
            {
                title: 'Phones',
                url: baseUrl + 'phones'
            },
            {
                title: 'Tablets',
                url: baseUrl + 'tablets'
            },
            {
                title: 'Wearables',
                url: baseUrl + 'wearables'
            },
        ]
    }
} ());