
<!-- ![.NET Core](https://github.com/yoyomooc/BlazorDemo/workflows/.NET%20Core/badge.svg) 
![Docker Image CI](https://github.com/yoyomooc/BlazorDemo/workflows/Docker%20Image%20CI/badge.svg) -->

# YoyoMooc.BlazorDemo

大家好，我使用Blazor 做了一个Demo，


以下地址，作为临时访问地址，后面可能随时会挂。。。

- 负载均衡的地址：http://23.97.69.94:3055/
- webapi地址：http://23.97.69.94:3001/api/student
- blazor直接访问地址：http://23.97.69.94:1805/

监控信息： http://23.97.69.94:1936/ 

  
网站Demo采用Blazor 开发完成,整个网站没有包含一行javascript和ts文件

- Blazor 解决了 Angular、Vue、React 的SSO问题，
- Blazor解决了 前端项目编译Angular、Vue、React慢的问题，
- 传统MVC、RazorPage在Ajax上需要通过js进行Dom操作的问题，被Blazor解决了双向绑定问题解决了，

### 总结一下，优秀

- Demo源代码：https://github.com/yoyomooc/BlazorDemo

 
运行在Docker容器中，没有错。都在Docker中。



数据库：SqlServer 2019

 



## 运行方式

已经内置了docker-compose 脚本， 启动

```bash

docker-compose pull

docker-compose up -d

docker-compose -down 


``` 
搞定。。
> ps: 前提是你会docker。。。
