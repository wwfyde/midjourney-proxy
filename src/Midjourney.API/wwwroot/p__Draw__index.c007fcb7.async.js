"use strict";(self.webpackChunkmidjourney_proxy_admin=self.webpackChunkmidjourney_proxy_admin||[]).push([[903],{39936:function(Nr,be,l){l.r(be),l.d(be,{default:function(){return Za}});var ua=l(97857),T=l.n(ua),da=l(15009),I=l.n(da),ca=l(64599),_=l.n(ca),pa=l(19632),ga=l.n(pa),fa=l(99289),$=l.n(fa),ma=l(5574),m=l.n(ma),P=l(66927),va=l(18429),ha=l(51042),Ce=l(52645),Sa=l(90930),ba=l(80854),L=l(55102),se=l(4393),Ca=l(16568),b=l(2453),A=l(14726),wa=l(7134),N=l(86250),V=l(42075),ya=l(66309),ja=l(11499),we=l(74330),Ta=l(38703),J=l(66476),ye=l(78045),je=l(85886),Ia=l(17910),g=l(67294),Te=l(37823),oe={cardTitleTime:"cardTitleTime___ULudn",taskErrorTip:"taskErrorTip___EJ9yV"},r=l(85893),Ie=L.Z.TextArea,Pa=se.Z.Meta,xa=function(){var Aa=Ca.ZP.useNotification(),Pe=m()(Aa,2),B=Pe[0],Ea=Pe[1],Ma=(0,g.useState)([]),xe=m()(Ma,2),Fa=xe[0],Ze=xe[1],ka=(0,g.useState)(!1),Ae=m()(ka,2),Ra=Ae[0],Ee=Ae[1],Ua=(0,g.useState)("imagine"),Me=m()(Ua,2),w=Me[0],Ba=Me[1],La=(0,g.useState)("MID_JOURNEY"),Fe=m()(La,2),j=Fe[0],Oa=Fe[1],Da=(0,g.useState)(""),ke=m()(Da,2),E=ke[0],H=ke[1],Na=(0,g.useState)("SQUARE"),Re=m()(Na,2),Ue=Re[0],Ja=Re[1],Wa=(0,g.useState)([]),Be=m()(Wa,2),O=Be[0],G=Be[1],Va=(0,g.useState)([]),Le=m()(Va,2),k=Le[0],ee=Le[1],Ha=(0,g.useState)([]),Oe=m()(Ha,2),R=Oe[0],ae=Oe[1],Ga=(0,g.useState)(""),De=m()(Ga,2),Ya=De[0],Ne=De[1],$a=(0,g.useState)(!1),Je=m()($a,2),W=Je[0],x=Je[1],za=(0,g.useState)(new Set),Xa=m()(za,1),y=Xa[0],Qa=(0,g.useState)(!1),We=m()(Qa,2),Ka=We[0],z=We[1],qa=(0,g.useState)(""),Ve=m()(qa,2),_a=Ve[0],er=Ve[1],ar=(0,g.useState)(""),He=m()(ar,2),ne=He[0],Ge=He[1],rr=(0,g.useState)(""),Ye=m()(rr,2),ue=Ye[0],tr=Ye[1],sr=(0,g.useState)(""),$e=m()(sr,2),ie=$e[0],ze=$e[1],nr=(0,g.useState)(0),Xe=m()(nr,2),Qe=Xe[0],ir=Xe[1],lr=(0,g.useState)(!1),Ke=m()(lr,2),or=Ke[0],ur=Ke[1],dr=(0,g.useState)(!1),qe=m()(dr,2),cr=qe[0],_e=qe[1],pr=(0,g.useState)([]),ea=m()(pr,2),gr=ea[0],fr=ea[1],mr=(0,g.useState)(),aa=m()(mr,2),X=aa[0],vr=aa[1],u=(0,ba.useIntl)(),de=(0,g.useRef)([]),Q=(0,g.useRef)(null),D="midjourney-proxy-admin",ce=sessionStorage.getItem("mj-image-prefix")||"";(0,g.useEffect)(function(){return br({state:D,pageNumber:0,pageSize:3,statusSet:["NOT_START","SUBMITTED","IN_PROGRESS","FAILURE","SUCCESS"],sort:"submitTime,desc"}),Q.current&&clearInterval(Q.current),Q.current=setInterval(function(){y.size!==0&&hr()},2e3),function(){Q.current&&(clearInterval(Q.current),Q.current=null)}},[]);var hr=function(){var n=$()(I()().mark(function e(){var a,o,i,f,s,p,c,F,v,h,C;return I()().wrap(function(S){for(;;)switch(S.prev=S.next){case 0:return a=Array.from(y),o=new Set(a),S.next=4,(0,P.BX)(a);case 4:i=S.sent,f=!1,s=ga()(de.current),p=_()(i),S.prev=8,F=I()().mark(function q(){var U,t;return I()().wrap(function(Z){for(;;)switch(Z.prev=Z.next){case 0:U=c.value,o.delete(U.id),(U.status==="FAILURE"||U.status==="SUCCESS"||U.status==="CANCEL")&&y.delete(U.id),t=s.find(function(Dr){return Dr.id===U.id}),t?Sr(t,U)||(f=!0,s.splice(s.indexOf(t),1,U)):(f=!0,s.push(U));case 5:case"end":return Z.stop()}},q)}),p.s();case 11:if((c=p.n()).done){S.next=15;break}return S.delegateYield(F(),"t0",13);case 13:S.next=11;break;case 15:S.next=20;break;case 17:S.prev=17,S.t1=S.catch(8),p.e(S.t1);case 20:return S.prev=20,p.f(),S.finish(20);case 23:v=_()(o);try{for(v.s();!(h=v.n()).done;)C=h.value,y.delete(C)}catch(q){v.e(q)}finally{v.f()}f&&(de.current=s,Ze(s),ra());case 26:case"end":return S.stop()}},e,null,[[8,17,20,23]])}));return function(){return n.apply(this,arguments)}}(),Sr=function(e,a){return e.status===a.status&&e.progress===a.progress&&e.imageUrl===a.imageUrl},ra=function(){setTimeout(function(){var e=document.getElementById("task-panel");e&&e.scrollTo(0,e.scrollHeight)},20)},br=function(){var n=$()(I()().mark(function e(a){var o,i,f,s,p,c;return I()().wrap(function(v){for(;;)switch(v.prev=v.next){case 0:return Ee(!0),v.next=3,(0,P.Ed)();case 3:return o=v.sent,fr(o),v.next=7,(0,P.Pn)(a);case 7:i=v.sent,f=i.list.reverse(),s=_()(f);try{for(s.s();!(p=s.n()).done;)c=p.value,c.status!=="FAILURE"&&c.status!=="SUCCESS"&&c.action!=="CANCEL"&&y.add(c.id)}catch(h){s.e(h)}finally{s.f()}de.current=f,Ze(f),Ee(!1),ra();case 15:case"end":return v.stop()}},e)}));return function(a){return n.apply(this,arguments)}}(),Cr=function(e){Ba(e),H(""),G([])},wr=function(e){vr(e)},yr=function(e){var a=e.target.value;Oa(a),H(""),G([])},jr=function(e){var a=e.target.value;Ja(a)},le=function(e){H(e.target.value)},ta=function(e){Ge(e.target.value)},K=function(){var n=$()(I()().mark(function e(a){return I()().wrap(function(i){for(;;)switch(i.prev=i.next){case 0:return i.next=2,new Promise(function(f){var s=new FileReader;s.onload=function(){return f(s.result)},s.readAsDataURL(a)});case 2:return i.abrupt("return",i.sent);case 3:case"end":return i.stop()}},e)}));return function(a){return n.apply(this,arguments)}}(),M=function(){var n=$()(I()().mark(function e(){var a,o,i,f,s,p,c,F,v,h,C,te,S,q;return I()().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:if(!(j==="INSIGHT_FACE"||j==="FACE_SWAP")){t.next=26;break}if(!(k.length<1)){t.next=4;break}return b.ZP.error(u.formatMessage({id:"pages.draw.swapTip"})),t.abrupt("return");case 4:if(!(R.length<1)){t.next=7;break}return b.ZP.error(u.formatMessage({id:"pages.draw.swapTip"})),t.abrupt("return");case 7:if(x(!0),a={sourceUrl:"",targetUrl:"",sourceBase64:"",targetBase64:"",state:D},!k[0].originFileObj){t.next=15;break}return t.next=12,K(k[0].originFileObj);case 12:a.sourceBase64=t.sent,t.next=16;break;case 15:a.sourceUrl=k[0].name;case 16:if(!R[0].originFileObj){t.next=22;break}return t.next=19,K(R[0].originFileObj);case 19:a.targetBase64=t.sent,t.next=23;break;case 22:a.targetUrl=R[0].name;case 23:(0,P.Vl)(a).then(function(d){x(!1),d.code===22||d.code===1?(d.code===22?B.warning({message:"warn",description:d.description}):b.ZP.success(u.formatMessage({id:"pages.draw.submitSuccess"})),y.add(d.result),ee([]),ae([])):B.error({message:"error",description:d.description})}),t.next=143;break;case 26:if(j!=="VIDEO_FACE_SWAP"){t.next=51;break}if(!(k.length<1)){t.next=30;break}return b.ZP.error(u.formatMessage({id:"pages.draw.swapTip"})),t.abrupt("return");case 30:if(!(R.length<1)){t.next=33;break}return b.ZP.error(u.formatMessage({id:"pages.draw.swapTip"})),t.abrupt("return");case 33:if(x(!0),o={sourceUrl:"",targetUrl:"",sourceBase64:"",targetBase64:"",state:D},!k[0].originFileObj){t.next=41;break}return t.next=38,K(k[0].originFileObj);case 38:o.sourceBase64=t.sent,t.next=42;break;case 41:o.sourceUrl=k[0].name;case 42:i=new FormData,R[0].originFileObj?i.append("TargetFile",R[0].originFileObj):o.targetUrl=R[0].name,i.append("SourceBase64",o.sourceBase64||""),i.append("SourceUrl",o.sourceUrl||""),i.append("TargetUrl",o.targetUrl||""),i.append("Satate",o.state),(0,P.Wv)(i,{headers:{"Content-Type":"multipart/form-data"}}).then(function(d){x(!1),d.code===22||d.code===1?(d.code===22?B.warning({message:"warn",description:d.description}):b.ZP.success(u.formatMessage({id:"pages.draw.submitSuccess"})),y.add(d.result),ee([]),ae([])):B.error({message:"error",description:d.description})}),t.next=143;break;case 51:if(w!=="show"){t.next=59;break}if(E){t.next=55;break}return b.ZP.error(u.formatMessage({id:"pages.draw.taskIdNotBlank"})),t.abrupt("return");case 55:y.add(E),H(""),t.next=143;break;case 59:if(w!=="showjobid"){t.next=67;break}if(E){t.next=63;break}return b.ZP.error(u.formatMessage({id:"pages.draw.promptNotBlank"})),t.abrupt("return");case 63:x(!0),(0,P.cq)("show",{botType:j,jobId:E,state:D,accountFilter:{instanceId:X}}).then(function(d){x(!1);var Z=re(d);Z&&(y.add(d.result),H(""),G([]))}),t.next=143;break;case 67:if(w!=="imagine"){t.next=95;break}if(E){t.next=71;break}return b.ZP.error(u.formatMessage({id:"pages.draw.promptNotBlank"})),t.abrupt("return");case 71:x(!0),f=[],s=_()(O),t.prev=74,s.s();case 76:if((p=s.n()).done){t.next=84;break}return c=p.value,t.next=80,K(c.originFileObj);case 80:F=t.sent,f.push(F);case 82:t.next=76;break;case 84:t.next=89;break;case 86:t.prev=86,t.t0=t.catch(74),s.e(t.t0);case 89:return t.prev=89,s.f(),t.finish(89);case 92:(0,P.qJ)(w,{botType:j,prompt:E,base64Array:f,state:D,accountFilter:{instanceId:X}}).then(function(d){x(!1);var Z=re(d);Z&&(y.add(d.result),H(""),G([]))}),t.next=143;break;case 95:if(w!=="blend"){t.next=123;break}if(!(O.length<2)){t.next=99;break}return b.ZP.error(u.formatMessage({id:"pages.draw.blendTip"})),t.abrupt("return");case 99:x(!0),v=[],h=_()(O),t.prev=102,h.s();case 104:if((C=h.n()).done){t.next=112;break}return te=C.value,t.next=108,K(te.originFileObj);case 108:S=t.sent,v.push(S);case 110:t.next=104;break;case 112:t.next=117;break;case 114:t.prev=114,t.t1=t.catch(102),h.e(t.t1);case 117:return t.prev=117,h.f(),t.finish(117);case 120:(0,P.qJ)(w,{botType:j,base64Array:v,dimensions:Ue,state:D,accountFilter:{instanceId:X}}).then(function(d){x(!1);var Z=re(d);Z&&(y.add(d.result),G([]))}),t.next=143;break;case 123:if(w!=="describe"){t.next=134;break}if(!(O.length<1)){t.next=127;break}return b.ZP.error(u.formatMessage({id:"pages.draw.imageEmptyTip"})),t.abrupt("return");case 127:return x(!0),t.next=130,K(O[0].originFileObj);case 130:q=t.sent,(0,P.qJ)(w,{botType:j,base64:q,state:D,accountFilter:{instanceId:X}}).then(function(d){x(!1);var Z=re(d);Z&&(y.add(d.result),G([]))}),t.next=143;break;case 134:if(w!=="shorten"){t.next=142;break}if(E){t.next=138;break}return b.ZP.error(u.formatMessage({id:"pages.draw.promptNotBlank"})),t.abrupt("return");case 138:x(!0),(0,P.qJ)(w,{botType:j,prompt:E,state:D,accountFilter:{instanceId:X}}).then(function(d){x(!1);var Z=re(d);Z&&(y.add(d.result),H(""))}),t.next=143;break;case 142:b.ZP.error(u.formatMessage({id:"pages.draw.unsupportedAction"}));case 143:case"end":return t.stop()}},e,null,[[74,86,89,92],[102,114,117,120]])}));return function(){return n.apply(this,arguments)}}(),re=function(e){return e.code===22||e.code===1?(e.code===22?B.warning({message:"warn",description:e.description}):b.ZP.success(u.formatMessage({id:"pages.draw.submitSuccess"})),!0):(B.error({message:"error",description:e.description}),!1)},Tr=function(e,a){var o=a.customId,i=e.id,f="".concat(a.emoji," ").concat(a.label);Ne("".concat(i,":").concat(o)),(0,P.qJ)("action",{taskId:i,customId:o,state:D,chooseSameChannel:!0}).then(function(s){if(Ne(""),s.code===22)B.warning({message:"warn",description:s.description}),a.style=3,y.add(s.result);else if(s.code===21){if(a.style=3,er("".concat(s.result," ").concat(f)),tr(s.result),Ge(s.properties.finalPrompt),ur(s.properties.remix||!1),o.startsWith("MJ::Inpaint:")){var p="".concat(ce).concat(e.imageUrl),c=new Image;c.src=p,c.onload=function(){ir(Math.floor(550/c.width*c.height)),ze(p),z(!0),setTimeout(function(){Ir()},300)}}else ze(""),z(!0);z(!0)}else if(s.code===1){if(a.style=3,s.result){var F=s.result.split(",");F.forEach(function(v){y.add(v)})}b.ZP.success(u.formatMessage({id:"pages.draw.actionSuccess"}))}else B.error({message:"error",description:s.description})})},pe=!1,ge=0,fe=0,Ir=function(){var e=document.getElementById("canvas");e.width=e.clientWidth,e.height=e.clientHeight;var a=e.getBoundingClientRect(),o=Math.floor(a.left),i=Math.floor(a.top),f=e.getContext("2d");f.fillStyle="blue",e.onmousedown=function(s){ge=s.clientX,fe=s.clientY,pe=!0},e.onmousemove=function(s){pe===!0&&f.fillRect(ge-o,fe-i,s.clientX-ge,s.clientY-fe)},e.onmouseup=function(){pe=!1}},Pr=function(){(0,P.el)(ue),z(!1)},xr=function(){var n=$()(I()().mark(function e(){var a,o,i,f;return I()().wrap(function(p){for(;;)switch(p.prev=p.next){case 0:if(_e(!0),!ie){p.next=11;break}return o=document.getElementById("canvas"),i=new Image,i.src=o.toDataURL("image/png"),p.next=7,Zr(i);case 7:f=p.sent,a={maskBase64:f,taskId:ue,prompt:ne},p.next=12;break;case 11:a={taskId:ue,prompt:ne};case 12:(0,P.qJ)("modal",a).then(function(c){_e(!1),c.code===22?(B.warning({message:"warn",description:c.description}),y.add(c.result),z(!1)):c.code===1?(y.add(c.result),z(!1),b.ZP.success(u.formatMessage({id:"pages.draw.subSuccess"}))):B.error({message:"error",description:c.description})});case 13:case"end":return p.stop()}},e)}));return function(){return n.apply(this,arguments)}}(),Zr=function(){var n=$()(I()().mark(function e(a){return I()().wrap(function(i){for(;;)switch(i.prev=i.next){case 0:return i.next=2,new Promise(function(f){a.onload=function(){var s=a.width,p=a.height,c=document.createElement("canvas"),F=c.getContext("2d");c.width=s,c.height=p,F.drawImage(a,0,0,s,p);for(var v=F.getImageData(0,0,s,p),h=v.data,C=0;C<h.length;C+=4)h[C]!==0||h[C+1]!==0||h[C+2]!==0?(h[C]=parseInt("0xff"),h[C+1]=parseInt("0xff"),h[C+2]=parseInt("0xff")):(h[C]=0,h[C+1]=0,h[C+2]=0,h[C+3]=255);F.putImageData(v,0,0);var te=c.toDataURL("png");f(te)}});case 2:return i.abrupt("return",i.sent);case 3:case"end":return i.stop()}},e)}));return function(a){return n.apply(this,arguments)}}(),Ar=function(e){var a="Midjourney - ".concat(e.displays.discordInstanceId);return e.botType==="NIJI_JOURNEY"?a="niji\u30FBjourney - ".concat(e.displays.discordInstanceId):(e.botType==="INSIGHT_FACE"||e.botType==="FACE_SWAP")&&(a="InsightFaceSwap - ".concat(e.displays.discordInstanceId)),e.status!=="SUCCESS"&&e.status!=="FAILURE"&&e.status!=="CANCEL"&&e.action!=="SWAP_FACE"?(0,r.jsxs)(r.Fragment,{children:[(0,r.jsx)("span",{children:a}),(0,r.jsx)("span",{className:oe.cardTitleTime,children:e.displays.submitTime}),(0,r.jsx)(A.ZP,{style:{marginLeft:"10px"},type:"link",shape:"circle",icon:(0,r.jsx)(va.Z,{}),onClick:function(){return(0,P.el)(e.id)}})]}):(0,r.jsxs)(r.Fragment,{children:[(0,r.jsx)("span",{children:a}),(0,r.jsx)("span",{className:oe.cardTitleTime,children:e.displays.submitTime})]})},Er=function(e){var a=e.description,o=e.properties.messageContent;return o&&(a=o.replace(/<@[^>]+>/g,"")),(0,r.jsx)(Te.U,{children:a})},Mr=function(){return Fa.map(function(e){var a="./midjourney.webp";return e.botType==="NIJI_JOURNEY"?a="./niji.webp":(e.botType==="INSIGHT_FACE"||e.botType==="FACE_SWAP"||e.botType==="VIDEO_FACE_SWAP")&&(a="./insightface.webp"),(0,r.jsxs)(se.Z,{bordered:!1,bodyStyle:{backgroundColor:"#eaeaea",marginBottom:"10px"},children:[(0,r.jsx)(Pa,{avatar:(0,r.jsx)(wa.C,{src:a}),title:Ar(e),description:Er(e)}),(0,r.jsxs)(N.Z,{vertical:!0,style:{paddingLeft:"48px"},children:[Ur(e),(0,r.jsx)(V.Z,{wrap:!0,style:{marginTop:"7px"},children:Rr(e)})]})]},e.id)})},sa=function(e){if(!e.properties.finalPrompt)return(0,r.jsx)(r.Fragment,{});var a=e.properties.finalPrompt;return(0,r.jsx)(Te.U,{children:a.replace(new RegExp("(?<!\\n)\\n","g"),`

`)})},me=function(e){if(e.status==="FAILURE")return(0,r.jsx)("span",{className:oe.taskErrorTip,children:e.failReason});if(e.status==="SUCCESS")return(0,r.jsx)(r.Fragment,{});if(e.status==="IN_PROGRESS")return(0,r.jsx)(r.Fragment,{children:kr(e)});var a="purple";return e.status==="SUBMITTED"?a="lime":e.status==="CANCEL"?a="magenta":e.status==="MODAL"&&(a="warning"),(0,r.jsx)("span",{children:(0,r.jsx)(ya.Z,{color:a,children:e.displays.status})})},na=function(e,a){return e?(0,r.jsx)(ja.Z,{width:a,src:"".concat(ce).concat(e),placeholder:(0,r.jsx)(we.Z,{tip:"Loading",size:"large"})}):(0,r.jsx)(r.Fragment,{})},Fr=function(e,a){return e?(0,r.jsx)("video",{width:a,controls:!0,src:ce+e,placeholder:(0,r.jsx)(we.Z,{tip:"Loading",size:"large"})}):(0,r.jsx)(r.Fragment,{})},kr=function(e){var a=e.progress,o=0;return a&&a.indexOf("%")>0&&(o=parseInt(a.substring(0,a.indexOf("%")))),(0,r.jsx)("span",{style:{width:250},children:(0,r.jsx)(Ta.Z,{percent:o,status:"normal"})})},Rr=function(e){return e.buttons.map(function(a){return(0,r.jsxs)(A.ZP,{ghost:!0,style:{backgroundColor:a.style===3?"#258146":"rgb(131 133 142)"},onClick:function(){Tr(e,a)},loading:Ya==="".concat(e.id,":").concat(a.customId),children:[a.emoji," ",a.label]},"".concat(e.id,":").concat(a.customId))})},Y=(0,r.jsxs)("div",{children:[(0,r.jsx)(ha.Z,{}),(0,r.jsx)("div",{style:{marginTop:8},children:"Upload"})]}),Ur=function(e){return e.action==="DESCRIBE"?(0,r.jsxs)(r.Fragment,{children:[me(e)," ",sa(e)," ",na(e.imageUrl,120)]}):e.action==="SHORTEN"?(0,r.jsxs)(r.Fragment,{children:[me(e)," ",sa(e)]}):(0,r.jsxs)(r.Fragment,{children:[me(e),e.action==="SWAP_VIDEO_FACE"?(0,r.jsx)(r.Fragment,{children:Fr(e.imageUrl,250)}):na(e.imageUrl,250)]})},Br=function(){return j==="INSIGHT_FACE"||j==="FACE_SWAP"?(0,r.jsxs)(N.Z,{vertical:!0,gap:8,children:[(0,r.jsx)(J.Z,T()(T()({},la),{},{listType:"picture-card",children:k.length>=1?null:Y})),(0,r.jsx)(L.Z,{onChange:function(a){a.target.value&&ee([{uid:"1",name:a.target.value,url:a.target.value}])},placeholder:u.formatMessage({id:"pages.draw.swap1Desc"})}),(0,r.jsx)(J.Z,T()(T()({},oa),{},{listType:"picture-card",children:R.length>=1?null:Y})),(0,r.jsx)(L.Z,{onChange:function(a){a.target.value&&ae([{uid:"2",name:a.target.value,url:a.target.value}])},placeholder:u.formatMessage({id:"pages.draw.swap2Desc"})}),(0,r.jsx)(A.ZP,{style:{marginTop:"10px"},type:"primary",onClick:M,loading:W,children:u.formatMessage({id:"pages.draw.swapDesc"})})]}):j==="VIDEO_FACE_SWAP"?(0,r.jsxs)(N.Z,{vertical:!0,gap:8,children:[(0,r.jsx)(J.Z,T()(T()({},la),{},{listType:"picture-card",children:k.length>=1?null:Y})),(0,r.jsx)(L.Z,{onChange:function(a){a.target.value&&ee([{uid:"1",name:a.target.value,url:a.target.value}])},placeholder:u.formatMessage({id:"pages.draw.swap1Desc"})}),(0,r.jsx)(J.Z,T()(T()({},oa),{},{listType:"picture-card",children:R.length>=1?null:Y})),(0,r.jsx)(L.Z,{onChange:function(a){a.target.value&&ae([{uid:"2",name:a.target.value,url:a.target.value}])},placeholder:u.formatMessage({id:"pages.draw.swap2VidelDesc"})}),(0,r.jsx)(A.ZP,{style:{marginTop:"10px"},type:"primary",onClick:M,loading:W,children:u.formatMessage({id:"pages.draw.swapVideoDesc"})})]}):w==="show"?(0,r.jsxs)(V.Z.Compact,{style:{width:"100%"},children:[(0,r.jsx)(L.Z,{placeholder:u.formatMessage({id:"pages.draw.inputIdShow"}),value:E,onChange:le,onPressEnter:M}),(0,r.jsx)(A.ZP,{type:"primary",onClick:M,loading:W,children:u.formatMessage({id:"pages.draw.submitTask"})})]}):w==="showjobid"?(0,r.jsxs)(V.Z.Compact,{style:{width:"100%"},children:[(0,r.jsx)(L.Z,{placeholder:u.formatMessage({id:"pages.draw.inputJobIdShow"}),value:E,onChange:le,onPressEnter:M}),(0,r.jsx)(A.ZP,{type:"primary",onClick:M,loading:W,children:u.formatMessage({id:"pages.draw.submitTask"})})]}):w==="imagine"?(0,r.jsxs)(N.Z,{vertical:!0,children:[(0,r.jsx)(J.Z,T()(T()({},Se),{},{listType:"picture-card",children:O.length>=5?null:Y})),(0,r.jsxs)(V.Z.Compact,{style:{width:"100%",marginTop:"10px"},children:[(0,r.jsx)(L.Z,{placeholder:"Prompt",value:E,onChange:le,onPressEnter:M}),(0,r.jsx)(A.ZP,{type:"primary",onClick:M,loading:W,children:u.formatMessage({id:"pages.draw.submitTask"})})]})]}):w==="blend"?(0,r.jsxs)(N.Z,{vertical:!0,children:[(0,r.jsx)(J.Z,T()(T()({},Se),{},{listType:"picture-card",children:O.length>=5?null:Y})),(0,r.jsxs)(V.Z,{style:{width:"100%",marginTop:"10px"},children:[(0,r.jsx)(ye.ZP.Group,{value:Ue,onChange:jr,options:[{value:"PORTRAIT",label:u.formatMessage({id:"pages.draw.PORTRAIT"})},{value:"SQUARE",label:u.formatMessage({id:"pages.draw.SQUARE"})},{value:"LANDSCAPE",label:u.formatMessage({id:"pages.draw.LANDSCAPE"})}],optionType:"button"}),(0,r.jsx)(A.ZP,{type:"primary",onClick:M,loading:W,children:u.formatMessage({id:"pages.draw.submitTask"})})]})]}):w==="describe"?(0,r.jsxs)(N.Z,{vertical:!0,children:[(0,r.jsx)(J.Z,T()(T()({},Se),{},{listType:"picture-card",children:O.length>=1?null:Y})),(0,r.jsx)(A.ZP,{style:{marginTop:"10px"},type:"primary",onClick:M,loading:W,children:u.formatMessage({id:"pages.draw.submitTask"})})]}):w==="shorten"?(0,r.jsxs)(V.Z.Compact,{style:{width:"100%",marginTop:"10px"},children:[(0,r.jsx)(L.Z,{placeholder:"Prompt",value:E,onChange:le,onPressEnter:M}),(0,r.jsx)(A.ZP,{type:"primary",onClick:M,loading:W,children:u.formatMessage({id:"pages.draw.submitTask"})})]}):(0,r.jsx)(r.Fragment,{})},ia=function(){var e=document.getElementById("canvas");e.width=e.clientWidth,e.height=e.clientHeight;var a=e.getContext("2d");a.fillStyle="blue"},Lr=function(){return ie?or?(0,r.jsxs)(N.Z,{vertical:!0,children:[(0,r.jsx)(A.ZP,{style:{marginBottom:"10px"},icon:(0,r.jsx)(Ce.Z,{}),onClick:ia,children:u.formatMessage({id:"pages.draw.clear"})}),(0,r.jsx)("canvas",{style:{backgroundImage:"url('".concat(ie,"')"),backgroundSize:"100% 100%"},id:"canvas",width:"550",height:Qe}),(0,r.jsx)(Ie,{style:{marginTop:"10px"},rows:2,value:ne,onChange:ta})]}):(0,r.jsxs)(N.Z,{vertical:!0,children:[(0,r.jsx)(A.ZP,{style:{marginBottom:"10px"},icon:(0,r.jsx)(Ce.Z,{}),onClick:ia,children:u.formatMessage({id:"pages.draw.clear"})}),(0,r.jsx)("canvas",{style:{backgroundImage:"url('".concat(ie,"')"),backgroundSize:"100% 100%"},id:"canvas",width:"550",height:Qe})]}):(0,r.jsx)(Ie,{rows:3,value:ne,onChange:ta})};function ve(n){n.onSuccess()}var he=function(e){var a=e.type==="image/jpeg"||e.type==="image/png"||e.type==="video/mp4"||e.type==="image/webp";a||b.ZP.error(u.formatMessage({id:"pages.draw.onlyJpgPng"}));var o=e.size/1024/1024<10;return o||b.ZP.error(u.formatMessage({id:"pages.draw.limit10M"})),a&&o||J.Z.LIST_IGNORE},Se={customRequest:ve,beforeUpload:he,fileList:O,onChange:function(e){G(e.fileList)},showUploadList:{showRemoveIcon:!0,showPreviewIcon:!1}},la={customRequest:ve,beforeUpload:he,maxCount:1,fileList:k,onChange:function(e){ee(e.fileList)},showUploadList:{showRemoveIcon:!0,showPreviewIcon:!1}},oa={customRequest:ve,beforeUpload:he,maxCount:1,fileList:R,onChange:function(e){ae(e.fileList)},showUploadList:{showRemoveIcon:!0,showPreviewIcon:!1}},Or=function(){var e,a=!1;j==="INSIGHT_FACE"||j==="FACE_SWAP"||j==="VIDEO_FACE_SWAP"?(a=!0,e=[{value:"swap",label:"/swap"}]):e=[{value:"imagine",label:"/imagine"},{value:"blend",label:"/blend"},{value:"describe",label:"/describe"},{value:"shorten",label:"/shorten"},{value:"showjobid",label:"/show job_id"},{value:"show",label:"/show task_id"}];var o=gr.map(function(i){return{value:i.channelId,label:i.channelId+" - "+(i.remark||""),disabled:!i.enable||!i.running}});return(0,r.jsxs)(V.Z,{style:{marginBottom:"10px"},children:[(0,r.jsx)(je.Z,{value:a?"swap":w,style:{width:150},onChange:Cr,options:e}),(0,r.jsx)(je.Z,{value:X,style:{width:320},onChange:wr,options:o,allowClear:!0,placeholder:u.formatMessage({id:"pages.draw.selectAccount"})}),(0,r.jsx)(ye.ZP.Group,{value:j,onChange:yr,options:[{value:"MID_JOURNEY",label:"Midjourney"},{value:"NIJI_JOURNEY",label:"niji\u30FBjourney"},{value:"FACE_SWAP",label:"FaceSwap"},{value:"VIDEO_FACE_SWAP",label:"Video\u30FBFaceSwap"}],optionType:"button"})]})};return(0,r.jsxs)(Sa._z,{children:[Ea,(0,r.jsx)(se.Z,{style:{marginBottom:"15px",overflow:"auto",height:"70vh"},loading:Ra,id:"task-panel",children:Mr()}),(0,r.jsxs)(se.Z,{children:[Or(),Br()]}),(0,r.jsx)(Ia.Z,{title:_a,open:Ka,onCancel:Pr,onOk:xr,confirmLoading:cr,width:600,children:Lr()})]})},Za=xa}}]);
