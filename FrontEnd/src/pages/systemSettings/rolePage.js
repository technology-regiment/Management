import { Component } from 'react';
import { connect } from 'dva';
import {  Layout} from 'antd';
import Roles from './components/Roles';
import PageHeaderWrapper from '@/components/PageHeaderWrapper';

const { Content } = Layout;


class RolePage extends Component {

  render() {
    return (
      <div>
        <PageHeaderWrapper >

        </PageHeaderWrapper>
        <Content
          style={{
          margin: '24px 16px 0',
          padding: 24,
          background: '#fff',
          minHeight: '670px',
          }}>
          <div>
            <Roles />
          </div>
          </Content>
      </div>
    


    );
  }
}

export default connect()(RolePage);
