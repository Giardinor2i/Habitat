Habitat for FXM

FXM can be used to deploy a range of capabilities to external sites, from simple analytics tracking to complex federated experiences.  Federating Sitecore content on an external site is a relatively straight forward task if the requirements are limited to the following:
<ul>
    <li>Deploy one or more controls that don't specify placeholders</li>
    <li>The controls to be deployed inherit the styles and behaviors of the external site</li>
</ul>
On the other hand, if the requirement is to federate one or more controls that do specify placeholders (i.e from a page layout) and that also have their own CSS and JavaScript the challenges become apparent quickly:
<ul>
    <li><b>Controls that reference placeholders</b></li>
    <li><b>Isolating styles required by federated content from those of the host site</b></li>
    <li><b>Attaching event handlers to document elements loaded by FXM</b></li>
    <li><b>Varying a control's behavior when it's running in FXM</b></li>
    <li><b>Browser cross origin request sharing for static assets (e.g. fonts)</b></li>
</ul>
To illustrate some possible solutions to these challenges this fork federates the header and footer from the Habitat site.  I've also written a blog <a href="http://timbarreto.net/2016/09/17/fxm-exp/">post</a> that explains in detail the changes in this fork.

