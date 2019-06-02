import { Component } from 'react';
import { connect } from 'dva';
import {  Input,Col,Row,Layout} from 'antd';

import PageHeaderWrapper from '@/components/PageHeaderWrapper';

const { Content } = Layout;
class index extends Component {
 
  componentDidMount() {
    const { BMap, BMAP_STATUS_SUCCESS } = window
    var map = new BMap.Map("allmap"); // 创建Map实例
    map.centerAndZoom(new BMap.Point(108.953098279,34.2777998978), 11); // 初始化地图,设置中心点坐标和地图级别
    map.enableScrollWheelZoom(true);     //开启鼠标滚轮缩放
}


  render() {

    return (
      <div>
        <PageHeaderWrapper >
        </PageHeaderWrapper>
        <Content>
        <div id="allmap" style={{ position: "absolute", top: '12vh', left: 0, width: '100vw', height: '100vh' }}></div>
        </Content>
        
           
      </div>
    );
  }
}

export default index;

// import React, { Component } from 'react';
 
// class Welcome extends Component {
 
//     componentDidMount() {
//         const { BMap, BMAP_STATUS_SUCCESS } = window
//         var map = new BMap.Map("allmap"); // 创建Map实例
//         map.centerAndZoom(new BMap.Point(108.953098279,34.2777998978), 11); // 初始化地图,设置中心点坐标和地图级别
//         map.enableScrollWheelZoom(true);     //开启鼠标滚轮缩放
//     }
 
//     render() {
//         return (
//             <div id="allmap" style={{ position: "absolute", top: 0, left: 0, width: '100vw', height: '100vh' }}></div>
//         );
//     }
// }
// export default Welcome;