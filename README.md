
<!-- ![.NET Core](https://github.com/yoyomooc/BlazorDemo/workflows/.NET%20Core/badge.svg) 
![Docker Image CI](https://github.com/yoyomooc/BlazorDemo/workflows/Docker%20Image%20CI/badge.svg) -->

# YoyoMooc.BlazorDemo

大家好，我使用Blazor 做了一个Demo，
build-and-push-image

以下地址，作为临时访问地址，

- 负载均衡的地址：http://23.97.69.94:3055/
- webapi地址：http://23.97.69.94:3001/api/student
- blazor直接访问地址：http://23.97.69.94:1805/

监控信息： http://23.97.69.94:1936/ 

  
网站Demo采用Blazor 开发完成,整个网站没有包含一行javascript和ts文件

- Blazor 解决了 Angular、Vue、React 的SSO问题，
- Blazor解决了 前端项目编译Angular、Vue、React慢的问题，
- 传统MVC、RazorPage在Ajax上需要通过js进行Dom操作的问题，被Blazor解决了双向绑定问题解决了，


源代码地址，每日自动同步更新

## 源代码下载

主仓库地址：[http://code.52abp.com/yoyomooc/blazordemo](http://code.52abp.com/yoyomooc/blazordemo)

镜像仓库地址以下：

- github：[https://github.com/yoyomooc/BlazorDemo](https://github.com/yoyomooc/BlazorDemo)

- 华为云cloud:[https://codehub.devcloud.cn-east-3.huaweicloud.com/docker_example00001/YoYoMooc.ExampleApp.git](https://codehub.devcloud.cn-east-3.huaweicloud.com/docker_example00001/YoYoMooc.ExampleApp.git)
- gitee:[https://gitee.com/yoyomooc/blazor-demo](https://gitee.com/yoyomooc/blazor-demo)


  ### 总结一下，优秀

 
运行在Docker容器中，没有错。都在Docker中。


数据库：SqlServer 2019





## 快速运行

已经内置了docker-compose 脚本， 启动

```bash

docker-compose pull

docker-compose up -d

docker-compose -down 


``` 
搞定。。
> ps: 前提是你会docker。。。
